        private static readonly ManualResetEvent _pauseFramesEvent = new ManualResetEvent(true);
            private PhotoCamera _cam; 
       private Thread _yFramesThread;
    private Dictionary<object, object> _hintDictionary;
---
     protected override void OnNavigatedTo(NavigationEventArgs e)
            {
                this._cam = new PhotoCamera();
                this._cam.Initialized += _cam_Initialized;
                    this._pumpYFrames = true;
                    this._isScanning = true;
                }
    
    
                CreateStandByTimer();
                this._yFramesThread = new Thread((PumpYFrames));
                this._yFramesThread.Start();
                base.OnNavigatedTo(e);
    
            }
    
        private void PumpYFrames()
                {
                    var array = new byte[307200];
                    while (_pumpYFrames)
                    {
                        _pauseFramesEvent.WaitOne();
                        if (this._isScanning)
                        {
                            bool flag;
                            try
                            {
                                this._cam.GetPreviewBufferY(array);
                                flag = true;
                            }
                            catch
                            {
                                flag = false;
                            }
                            if (flag)
                            {
                                var source = new RGBLuminanceSource(array, 640, 480, false);
                                var binarizer = new HybridBinarizer(source);
                                var image = new BinaryBitmap(binarizer);
                                Reader reader = new QRCodeReader();
                                try
                                {
                                    var results = reader.decode(image, _hintDictionary);
                                    ProcessScan(results);
        
                                }
                                catch (Exception ex)
                                {//catch logic
    
                                }
                            }
                        }
                    }
                }
