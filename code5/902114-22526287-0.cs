    private void BgWorkerMap_ProgressChanged_Handler(object sender, ProgressChangedEventArgs progressChangedArgs)
    {
            Src.Lock();
            int size = Src.BackBufferStride * Src.PixelHeight;
            // Copy the bitmap's data directly to the on-screen buffers
            // Method is DLL imported from kernel32.dll
            CopyMemory(Src.BackBuffer, TestBitmap[7].Wb.BackBuffer, size);
            Src.AddDirtyRect(new Int32Rect(0, 0, 256 * 3, 256));
            Src.Unlock();
    }
