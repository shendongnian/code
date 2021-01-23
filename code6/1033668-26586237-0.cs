       private void button1_Click(object sender, EventArgs e)
       {
           new Thread(testCapture).Start();
       }
       public void testCapture()
        {
            for (int i = 0; i < 200; i++)
            {
                Screenshot s = _captureProcess.CaptureInterface.GetScreenshot();
                Bitmap b = s.CapturedBitmap.ToBitmap();
                s.Dispose();
            }
        }
