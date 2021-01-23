    PictureBoxX pic = new PictureBoxX();
    pic.Image = someTransparentImage;
    pic.Click += (s,e) => {
       MessageBox.Show("Clicked on image!");
    };
