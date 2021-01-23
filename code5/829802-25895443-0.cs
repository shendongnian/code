    public class ImageUtilController : Controller
    {
        public FileContentResult GenerateTransparentRectangle(int width, int height)
        {
            var image = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            using (var g = Graphics.FromImage(image))
            {
                g.Clear(Color.Transparent);
                g.FillRectangle(new SolidBrush(Color.Transparent), 0, 0, width, height);
            }
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return File(ms.ToArray(), "image/png");
        }
    }
