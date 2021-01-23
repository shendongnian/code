       void myCamera_Initialized(object sender, CameraOperationCompletedEventArgs e)
        {
            try
            {
                if (e.Succeeded)
                {
                    
                }
            }
            catch
            {
                MessageBox.Show("Problem occured in camera initialization.");
            }
        }
     void camera_CaptureCompleted(object sender, CameraOperationCompletedEventArgs e)
            {
                try
                {
                    
                }
                catch
                {
                    MessageBox.Show("Captured image is not available, please try again.");
                }
            }
    void camera_CaptureImageAvailable(object sender, Microsoft.Devices.ContentReadyEventArgs e)
            {
                try
                {
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Captured image is not available, please try again.   " + ex.Message);
                }
    
            }
