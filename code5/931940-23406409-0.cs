    List<PictureBox> myPics = new List<PictureBox>();
    int picWidth = 100;
    int picHeight = 100;
    for (x = 0; x <= this.Width; x += picWidth) {
    	for (y = 0; y <= this.Height; y += picHeight) {
    		PictureBox pic = new PictureBox();
    		pic.Image = pic.Image;
    		// Your image
    		pic.Location = new Point(x, y);
    		this.Controls.Add(pic);
    		myPics.Add(pic);
    	}
    }
    
    // Do something with myPics...
