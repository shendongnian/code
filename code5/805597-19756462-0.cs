        if (SelectMedia.ShowDialog() == DialogResult.OK)
        {
            if (SelectMedia.FilterIndex == 1)
            {
                PictureViewer picture = new PictureViewer();
                picture.SetPicture(SelectMedia.FileName);
                FileNameLabel.Text = SelectMedia.FileName;
                picture.Show();
            }
