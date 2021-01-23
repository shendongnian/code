    PictureBox pb = new PictureBox();
    int newX = oldX + xOffset; // xOffset is whatever you're incrementing x by
    int newY = oldY + yOffset; // yOffset is whatever you're incrementing y by
    if (newX < 0) {
        newX = 0;
    } else if (newX > this.ClientSize.Width - pb.Width) {
	    newX = this.ClientSize.Width - pb.Width;
    }
    if (newY < 0) {
        newY = 0;
    } else if (newY > this.ClientSize.Height - pb.Height) {
	    newY = this.ClientSize.Height - pb.Height;
    }
	// New point to move it to
    Point newP = new Point(newX, newY);
