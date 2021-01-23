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
                DirectoryInfo di = new DirectoryInfo(sourceDirectory);
                FileInfo[] imagesToConvert = di.GetFiles("*.jpg");
    
                foreach(var image in imagesToConvert)
                {
                    using (Bitmap bmp = new Bitmap(image.FullName))
                    {
                        bmp.Save(Path.Combine(targetDirectory, image.Name), 
                            ImageFormat.Gif);
                    }
                }
            }
        }
    }
