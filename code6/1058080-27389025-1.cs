    using System.Drawing;
    using System.IO;
    using System.Web;
    using System.Web.Mvc;
    
    namespace MvcSandbox.Controllers
    {
        public class BitmapConvertController : Controller
        {
            public ActionResult Index()
            {
                return View();
            }
    
            [HttpPost]
            public ActionResult UploadImage(HttpPostedFileBase uploadFile)
            {
                var s = uploadFile.InputStream;
    
                var bitmap = new Bitmap(s);
    
                var resizedBitmap = new Bitmap(250, 250, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                resizedBitmap.SetResolution(72F, 72F);
    
                using (var g = Graphics.FromImage(resizedBitmap))
                {
                    g.Clear(Color.White);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(bitmap, 0, 0, 250, 250);
    
                    resizedBitmap.Save("C:\\Test\\test.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
    
                    using (var memoryStream = new MemoryStream())
                    {
                        resizedBitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
    
                        using (var dest = new FileStream("C:\\Test\\stream.jpg", FileMode.OpenOrCreate))
                        {
                            memoryStream.Seek(0, SeekOrigin.Begin); //go back to start
                            memoryStream.CopyTo(dest);
                        }
                    }
    
                }
    
                return RedirectToAction("Index");
            }
        }
    }
