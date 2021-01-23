    private void SetPictureBoxImage(Image img)
    {
        this.pictureBox1.Image = img;
        this.SetButtonEnabledState();
    }
    
    private void SetButtonEnabledState()
    {
        this.button2.Enabled = (this.pictureBox1.Image != null);
    }
