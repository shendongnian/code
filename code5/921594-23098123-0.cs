        public void updateImage(byte[] byteArray, UInt32 bufferSize, int cvtWidth, int cvtHeight)
        {
            Dispatcher.BeginInvoke(() =>
            {
                WriteableBitmap wb = new WriteableBitmap(cvtWidth, cvtHeight);
                System.Buffer.BlockCopy(byteArray, 0, wb.Pixels, 0, byteArray.Length);
                //wb.Invalidate();
                ImageScreen.Source = wb;
            });
        }
