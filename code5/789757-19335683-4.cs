    private void Picturebox_MouseEnter(object sender, EventArgs e)
    {
        PictureBox pb = sender as PictureBox;
        if (pb != null)
        {
            if (pb.Name == "PB2")
            {
                //Do PB2 specific task
            }
            //Your code when mouse enters one of the pictureboxes
            //Use Name property to determine wich one, if needed
        }
    }
    
    private void PictureBox_MouseLeave(object sender, EventArgs e)
    {
        //Your code when mouse leaves one of the pictureboxes
        //Use Name property to determine wich one, if needed
    }
