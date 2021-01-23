                if (cameraInit)
                {
                    Dispatcher.BeginInvoke(() =>
                    {
                        if (_photoCamera != null)
                        {
                            _photoCamera.Dispose();
                            _photoCamera.Initialized -= OnPhotoCameraInitialized;
                            _photoCamera.CaptureImageAvailable -= cam_CaptureImageAvailable;
                            _photoCamera.AutoFocusCompleted -= cam_AutoFocusCompleted;
                            _photoCamera = null;
                            cameraInit = false;
                        }
                    });
                }
