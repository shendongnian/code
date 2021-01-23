        void camera_CaptureCompleted(object sender, CameraOperationCompletedEventArgs e)
        {
            try
            {
                Deployment.Current.Dispatcher.BeginInvoke(delegate()
                {
                    try
                    {
                        cam.Dispose();
                        NavigationService.Navigate(new Uri("URI nething", UriKind.Relative));
                    }
                    catch (Exception)
                    {
                        
                         MessageBox.Show("Problem occured!!");
                    }
                });
            }
            catch
            {
                MessageBox.Show("Problem in camer_capturecompleted");
            }
        }
