        #region External
        [DllImport("kernel32.dll", EntryPoint = "RtlMoveMemory")]
        public static extern void CopyMemory(IntPtr destination, IntPtr source, uint length);
        #endregion
        private const int PixelHeight = 1024;
        private const int PixelWidth = 1024;
        private const int DpiHeight = 96;
        private const int DpiWidth = 96;
        private const int RgbBytesPerPixel = 3;
        WriteableBitmap _myBitmap = new WriteableBitmap(PixelHeight, PixelWidth, DpiHeight, DpiWidth, PixelFormats.Rgb24, null);
        private readonly byte[] _blankImage = new byte[PixelHeight * PixelWidth * RgbBytesPerPixel];
        private unsafe void FastClear()
        {
            fixed (byte* b = _blankImage)
            {
                CopyMemory(_myBitmap.BackBuffer, (IntPtr)b, (uint)_blankImage.Length);
            }
            Application.Current.Dispatcher.InvokeAsync(() =>
            {
                _myBitmap.Lock();
                _myBitmap.AddDirtyRect(new Int32Rect(0, 0, _myBitmap.PixelWidth, _myBitmap.PixelHeight));
                _myBitmap.Unlock();
            });
        }
        private void SafeClear()
        {
            GCHandle pinnedArray = new GCHandle();
            IntPtr pointer = IntPtr.Zero;
            try
            {
                //n.b. If pinnedArray is used often wrap it in a class with IDisopsable and keep it around
                pinnedArray = GCHandle.Alloc(_blankImage, GCHandleType.Pinned);
                pointer = pinnedArray.AddrOfPinnedObject();
                CopyMemory(_myBitmap.BackBuffer, pointer, (uint)_blankImage.Length);
                Application.Current.Dispatcher.InvokeAsync(() =>
                {
                    _myBitmap.Lock();
                    _myBitmap.AddDirtyRect(new Int32Rect(0, 0, _myBitmap.PixelWidth, _myBitmap.PixelHeight));
                    _myBitmap.Unlock();
                });
            }
            finally
            {
                pointer = IntPtr.Zero;
                pinnedArray.Free();
            }
        }
