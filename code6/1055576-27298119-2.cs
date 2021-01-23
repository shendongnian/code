    using System.Drawing.Imaging;
    using System.IO;
    using System.Drawing;
    
    namespace ConvertImagesFormats
    {
        class Program
        {
            static void Main(string[] args)
            {
                string sourceDirectory = @"C:\test";
                string targetDirectory = @"C:\test";
                ImageFormat imageFormat = ImageFormat.Gif;
                foreach(var image in Directory.GetFiles(sourceDirectory, "*.jpg"))
                {
                    using (Bitmap bmp = new Bitmap(image))
                    {
                        string targetName = Path.GetFileNameWithoutExtension(image) + "." + imageFormat;
                        bmp.Save(Path.Combine(targetDirectory, targetName), imageFormat);
                    }
                }
            }
        }
    }
