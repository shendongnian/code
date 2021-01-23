    int ISampleGrabberCB.BufferCB( double SampleTime, IntPtr pBuffer, int BufferLen )
    {
        // Avoid the possibility that someone is calling SetLogo() at this instant
        lock (this)
        {
            if (m_Bitmap != null)
            {                        
                Bitmap v;
                v = new Bitmap(m_videoWidth, m_videoHeight, m_stride, PixelFormat.Format24bppRgb, pBuffer);
               
                Graphics g = Graphics.FromImage(v);
                g.DrawImage(m_Bitmap, 100, 100, m_Bitmap.Width, m_Bitmap.Height);
                v = new Bitmap(v.Width, v.Height, g);
            }
        }
