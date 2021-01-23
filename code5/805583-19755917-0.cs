    class Program
    {
        static void Main(string[] args)
      {
         // Load the image.
         System.Drawing.Image image1 = System.Drawing.Image.FromFile(@"C:\test.bmp");
         // Save the image in JPEG format.
         image1.Save(@"C:\test.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
         // Save the image in GIF format.
         image1.Save(@"C:\test.gif", System.Drawing.Imaging.ImageFormat.Gif);
        // Save the image in PNG format.
        image1.Save(@"C:\test.png", System.Drawing.Imaging.ImageFormat.Png);        
       }
    }
