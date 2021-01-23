    void PictureBox_Click(object sender, EventArgs e)
    {
        var picBox = sender As PictureBox;
        if (picBox == null) return;
        //picBox is now whichever box was clicked
        // (assuming you set all your pictureboxes to use this handler)
    }
