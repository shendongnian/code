    protected override void OnNavigatedFrom(NavigationEventArgs e)
            {
             try
                {
                 while (!cameraInit)
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                    if (cameraInit)
                    {
                        Dispatcher.BeginInvoke(() => { 
                            if (cam != null)
                            {
                                cam.Dispose();
                                cam.CaptureCompleted -= cam_CaptureCompleted;
                                cam.CaptureImageAvailable -= cam_CaptureImageAvailable;
                                cam.AutoFocusCompleted -= cam_AutoFocusCompleted;
                                CameraButtons.ShutterKeyPressed -= OnButtonFullPress;
                                cam = null;
                                cameraInit = false;
                            }
                        });
                    }
    
                }
                catch (Exception ex)
                {
    
                    MessageBox.Show(ex.Message);
                }
    }
