    private void SwapImage(object sender, EventArgs e)
    {
        PictureBox pictureBox = sender as PictureBox;
        if (pictureBox != null)
        {
            pictureBox.BackColor = Color.Coral;
        }
        else
        {
            MessageBox.Show("What are you doing, you should be working!");
        }
    }
