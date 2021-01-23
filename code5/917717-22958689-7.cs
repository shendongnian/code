        private void btnShowPropertyPages_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (capture == null)
                    throw new ApplicationException("Please select a video and/or audio device.");
                if (!capture.Cued)
                    capture.Filename = txtFilename.Text;
                ShowPropertyPage(capture.VideoDevice, capture.VideoDevice.Name, this);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.ToString());
            }
        }
