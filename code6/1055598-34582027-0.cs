    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    using FreeImageAPI;
    
    namespace ConsoleApplication1
    {
       class Program
       {
          static void Main(string[] args)
          {  FIBITMAP bitmap;
             bool    success;
    
             SetOutputMessage(OutputMessage);
    
             Console.Write("Test 1... ");
             bitmap = FreeImage.CreateFromBitmap(new Bitmap(320, 240, PixelFormat.Format24bppRgb));
             success = FreeImage.Save(FREE_IMAGE_FORMAT.FIF_JPEG, bitmap, "output.jpg",   FREE_IMAGE_SAVE_FLAGS.JPEG_QUALITYNORMAL);
             FreeImage.Unload(bitmap);
             Console.WriteLine("Success");
    
             Console.Write("Test 2... ");
             bitmap = FreeImage.CreateFromBitmap(new Bitmap(320, 240));
             success = FreeImage.Save(FREE_IMAGE_FORMAT.FIF_JPEG, bitmap, "output.jpg",   FREE_IMAGE_SAVE_FLAGS.JPEG_QUALITYNORMAL);
             FreeImage.Unload(bitmap);
             Console.WriteLine("Success");
    
          }
    
          static void OutputMessage(FREE_IMAGE_FORMAT format, string message)
          {  throw new Exception(message);
          }
    
          [DllImport("FreeImage", EntryPoint = "FreeImage_SetOutputMessage")]
          internal static extern void SetOutputMessage(OutputMessageFunction outputMessageFunction);
    
       }
    }
