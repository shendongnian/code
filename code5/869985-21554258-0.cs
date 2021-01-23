        private void ApictureBox_Click(object sender, EventArgs e)
        {
            var clickedPicture = sender as PictureBox;
            // iterate through all picture controls of the current form
            for (var pic in this.Controls.OfType<PictureBox>())  
                if (pic.Tag="special")
                   Swap<Image>(ref clickedPicture.Image, ref pic.Image);
        }
