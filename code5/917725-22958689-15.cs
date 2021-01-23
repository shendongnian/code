        private void btnShowPropertyPages_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (capture == null)
                    throw new ApplicationException("Please select a video and/or audio device.");
                capture.ShowPropertyPage(capture.VideoDevice, this);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.ToString());
            }
        }
