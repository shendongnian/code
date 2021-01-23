    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    namespace BmpConverter
    {
        class Program
        {
            static void Main(string[] args)
            {
                if (args.Length < 1)
                {
                    Console.WriteLine("Usage:");
                    Console.WriteLine("");
                    Console.WriteLine("BmpConverter file.png");
                    Console.WriteLine();
                    return;
                }
                string filename = args[0];
                if (!File.Exists(filename))
                {
                    Console.WriteLine("Error: file does not exist!");
                    Console.WriteLine();
                    return;
                }
                if (Path.GetExtension(filename).ToUpper() != ".PNG")
                {
                    Console.WriteLine("Error: Only PNG files are supported!");
                    Console.WriteLine();
                    return;
                }
                string resultFilename;
                if (args.Length > 1 && args[1] != null)
                    resultFilename = args[1];
                else
                    resultFilename = Path.ChangeExtension(filename, ".BMP");
                Bitmap source = new Bitmap(filename);
                Bitmap destination = new Bitmap(source.Width, source.Height, PixelFormat.Format32bppRgb);
                for (int y = 0; y < source.Height; y++)
                {
                    byte[] sourceLine, destLine;
                    var sourceData = source.LockBits(new Rectangle(0, y, source.Width, 1), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                    var destData = destination.LockBits(new Rectangle(0, y, source.Width, 1), ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);
                    sourceLine = new byte[sourceData.Stride];
                    Marshal.Copy(sourceData.Scan0, sourceLine, 0, sourceData.Stride);
                    destLine = new byte[sourceLine.Length];
                    for (int x = 0; x < source.Width; x++)
                    {
                        bool transparent = sourceLine[x * 4 + 3] < 128;
                        destLine[x * 4] = transparent ? (byte)0 : sourceLine[x * 4];
                        destLine[x * 4 + 1] = transparent ? (byte)0 : sourceLine[x * 4 + 1];
                        destLine[x * 4 + 2] = transparent ? (byte)0 : sourceLine[x * 4 + 2];
                        destLine[x * 4 + 3] = transparent ? (byte)0 : (byte)255;
                    }
                    Marshal.Copy(destLine, 0, destData.Scan0, source.Width * 4);
                    source.UnlockBits(sourceData);
                    destination.UnlockBits(destData);
                }
                destination.Save(resultFilename, ImageFormat.Bmp);
            }
        }
    }
