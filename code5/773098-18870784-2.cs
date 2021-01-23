    public class sshot : screen
    {
        public void shot()
        {
            CaptureScreenToFile("C:\\Logs\\Screenshot" + DateTime.Now.ToString("ddMMyyyy") + ".jpg", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
