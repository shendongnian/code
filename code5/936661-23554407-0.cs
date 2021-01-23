        void FrameArrived(object sender, byte[] pixels)
        {
            //push pixels into list
            lock (_pixelList)
            {
                _pixelList.Add(pixels);
            }
            _waitHandle.Set();
            // 1. Create a bitmap and render it on an <Image> element (UI thread).
            DisplayBitmap(pixels);
            // 2. Pass the byte array to a method for video recording.
            //RecordBitmap(pixels);
        }
        AutoResetEvent _waitHandle = new AutoResetEvent(false);
        List<byte[]> _pixelList = new List<byte[]>();
        bool _stop = false;
        void StartProcessPixelsThread()
        {
            Task.Run(() =>
            {
                while (!_stop)
                {
                    _waitHandle.WaitOne();
                    while (true)
                    {
                        byte[] pixels;
                        lock (_pixelList)
                        {
                            if (_pixelList.Count > 0)
                            {
                                pixels = _pixelList[0];
                                _pixelList.RemoveAt(0);
                            }
                            else
                            {
                                break;
                            }
                        }
                        RecordBitmap(pixels);
                    }
                }
            });
        }
        void StopProcessPixelsThread()
        {
            _stop = true;
            _waitHandle.Set();
        }
