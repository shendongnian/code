    using System;
    using System.Drawing;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Read image into memory
                var img = new Bitmap(@"C:\Temp\MickyMouse.png");
                // Modify width of console buffer to keep each line of characters "on one line"
                Console.SetBufferSize(img.Width + 10, img.Height + 10);
                Console.WriteLine(ConvertToString(img));
                Console.ReadLine();
            }
            private static string ConvertToString(Bitmap image)
            {
                // Code from above
            }
        }
    }
