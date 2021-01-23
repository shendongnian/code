    using System.IO;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    
    namespace PNGEncoder
    {
        class Program
        {
            static void Main(string[] args)
            {
                var width = 256;
                var height = 256;
    
                var pngMetadata = new BitmapMetadata("png");
    
                pngMetadata.SetQuery("/iTXt/Keyword", "keyword0".ToCharArray());
                pngMetadata.SetQuery("/iTXt/TextEntry", "textentry0");
    
                pngMetadata.SetQuery("/[1]iTXt/Keyword", "keyword1".ToCharArray());
                pngMetadata.SetQuery("/[1]iTXt/TextEntry", "textentry1");
                var bitmap = new WriteableBitmap(width, height, 96, 96, PixelFormats.Gray8, null);
                var pixels = new ushort[width * height];
                for (var y = 0; y < height; y++)
                {
                    for (var x = 0; x < width; x++)
                    {
                        pixels[y * width + x] = (ushort)(65535 * (((x >> 4) ^ (y >> 4)) & 1));
                    }
                }
    
                bitmap.WritePixels(new Int32Rect(0, 0, width, height), pixels, width, 0);
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmap, null, pngMetadata, null));
                using (var stream = File.Create("checkerBoard.png"))
                {
                    encoder.Save(stream);
                }
            }
        }
    }
