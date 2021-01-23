    public static byte[] ConvertToEmf(string svgImage)
    {
        string emfTempPath = Path.GetTempFileName();
        try
        {
            var svg = SvgDocument.FromSvg<SvgDocument>(svgImage);
            using (Graphics bufferGraphics = Graphics.FromHwndInternal(IntPtr.Zero))
            {
                using (var metafile = new Metafile(emfTempPath, bufferGraphics.GetHdc()))
                {
                    using (Graphics graphics = Graphics.FromImage(metafile))
                    {
                        svg.Draw(graphics);
                    }
                }
            }
               
            return File.ReadAllBytes(emfTempPath);
        }
        finally
        {
            File.Delete(emfTempPath);
        }
    }
At first I create a temp file. Then I use Draw(Graphics) method that to save emf in it. And at last I read bytes from temp file.<br/>
Don't try to use MemoryStream for that. Unfortunately, it's not working.
