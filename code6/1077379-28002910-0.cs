    private void pb1_Click(object sender, EventArgs e)
    {
        SwapImages(sender as PictureBox);
    }
    private void SwapImages(PictureBox pb)
    {   
		if (pb.Image == img1)
		{
			pb.Image = img2;                    
		}            
    }
