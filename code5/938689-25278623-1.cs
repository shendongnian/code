    async private void FlashlightOn_Click(object sender, RoutedEventArgs e)
        {           
                // turn flashlight on
                CameraSensorLocation location = CameraSensorLocation.Back;
                if (this.audioCaptureDevice == null)
                {
                    audioCaptureDevice = await AudioVideoCaptureDevice.OpenAsync(location,
                    AudioVideoCaptureDevice.GetAvailableCaptureResolutions(location).First());
                }
                FlashOn(location, VideoTorchMode.On);
               }
            private void FlashlightOff_Click(object sender, RoutedEventAgrs e)
            {
                // turn flashlight off
                var sensorLocation = CameraSensorLocation.Back;
                FlashOn(sensorLocation, VideoTorchMode.Off);
            }
        
        public bool FlashOn(CameraSensorLocation location, VideoTorchMode mode)
        {
            // turn flashlight on/off
            var supportedCameraModes = AudioVideoCaptureDevice
                .GetSupportedPropertyValues(location, KnownCameraAudioVideoProperties.VideoTorchMode);
            if ((audioCaptureDevice != null) && (supportedCameraModes.ToList().Contains((UInt32)mode)))
            {
                audioCaptureDevice.SetProperty(KnownCameraAudioVideoProperties.VideoTorchMode, mode);
                return true;
            }
            return false;
        }
