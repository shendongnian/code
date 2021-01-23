        public void CaptureWindowToFile(IntPtr handle, string filename, ImageFormat format)
        {
            using(Image img = CaptureWindow(handle))
            {
                img.Save(filename, format);
            }
        }
        public void CaptureScreenToFile(string filename, ImageFormat format)
        {
            using(Image img = CaptureScreen())
            {
                img.Save(filename, format);
            }
        }
