    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
        mWriteableBitmap.Lock();
        for (int i = 0; i < 480; i++)
        {
            for (int j = 0; j < 640; j++)
            {
                setPixel(j, i, Color.FromRgb(255, 255, 255));
            }
        }
        mWriteableBitmap.AddDirtyRect(new Int32Rect(0, 0,
            mWriteableBitmap.PixelWidth, mWriteableBitmap.PixelHeight));
        mWriteableBitmap.Unlock();
        mImage.Source = mWriteableBitmap; // image is white now
    }
