    using ImageMagick;
    namespace JpegToPcx
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (MagickImage image = new MagickImage("MyFile.jpeg"))
                {
                    image.Write("MyFile.pcx");
                }
            }
        }
    }
