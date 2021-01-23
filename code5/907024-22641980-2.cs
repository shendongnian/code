    using System;
    using Cairo;
    namespace cairoTests
    {
        class Program
        {
            static void Main(string[] args)
            {            
                int height = 512;
                int width = 512;
                int stride = 4 * width; 
                int bmpSize = stride * height;
                byte[] bmp = new byte[bmpSize];
                using (ImageSurface surf =
                    new ImageSurface(bmp, Format.Argb32, width, height, stride))
                {
                    using (Context ctx = new Context(surf))
                    {
                        ctx.SetSourceRGB(1, 0, 0);
                        ctx.Rectangle(10, 10, 100, 100);
                        ctx.Fill();
                    }
                    surf.Flush();
                    //surf.WriteToPng(@"c:/test.png");
                }
                //now you have bmp filled, and may pass it to your game engine as texture             
            }
        }
    }
