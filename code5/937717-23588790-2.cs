    public class ImageProcessor
    {
        MemoryStream ms = new MemoryStream();
        StreamWriter sw;
        public Bitmap Rendering(string bmpPath)
        {
            sw = new StreamWriter(ms, System.Text.Encoding.UTF8);
        }
    }
