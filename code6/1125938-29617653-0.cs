    private void m_downloadButton_Click(object sender, EventArgs e)
    {
        using (var client = new WebClient())
        {
            var imageData = client.DownloadData(m_urlTextBox.Text);
    
            var converter = new ImageConverter();
            var image = (Image)converter.ConvertFrom(imageData);
    
            m_pictureBox.Image = image;
        }
    }
