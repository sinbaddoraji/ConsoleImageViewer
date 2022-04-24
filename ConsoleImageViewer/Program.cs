using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;

namespace ConsoleImageViewer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
                return;

            string output = Get_Image_String(args[0]);
            Console.WriteLine(output);
            File.WriteAllText(args[0] + ".txt", output);

            Console.ReadKey(true);
        }

        static string Get_Image_String(string image_path)
        {
            string output = "";

            Image image = Image.FromFile(image_path).GetThumbnailImage(25, 25, null, IntPtr.Zero);
            char[] chars = { '#', '#', '@', '%', '=', '+', '*', ':', '-', '.', ' ' };


            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color colour = ((Bitmap)image).GetPixel(x, y);
                    int index = (colour.R + colour.G + colour.B) / 3 * (chars.Length - 1) / 255;
                    output += chars[index].ToString();
                }
                output += "\n";
            }

            return output;
        }
    }
}
