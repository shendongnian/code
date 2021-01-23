        private object locker;
        private async void StartMeasure(object sender, RoutedEventArgs e)
        {
            lock (locker)
            {
                if (_recording)
                {
                    await _MediaCapture.StopPreviewAsync();
                }
                else
                {
                    await _MediaCapture.StartPreviewAsync();
                }
                _recording = !_recording;
                _MediaCapture.VideoDeviceController.TorchControl.Enabled = _recording;               
            }
        }
