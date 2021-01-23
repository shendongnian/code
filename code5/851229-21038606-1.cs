                if (e.Succeeded)
                {
                    cameraInit = true;
                    Dispatcher.BeginInvoke(() =>
                    {
                        gvCamera.Visibility = Visibility.Visible;
                        gvCameraImage.Visibility = Visibility.Collapsed;
                        Cancel.Visibility = Visibility.Visible;
                        imgScanCancle.Visibility = Visibility.Visible;
                        if (cameraInit)
                        {
                            _photoCamera.FlashMode = FlashMode.Auto;
                            _photoCamera.Focus();
                        }
                    });
                }
