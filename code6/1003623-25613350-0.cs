    PictureBox pb = new PictureBox();
    int newX = oldX + 1;
    int newY = oldY + 1;
    if (newX > this.ClientSize.Width - pb.Width) {
	    newX = this.ClientSize.Width - pb.Width;
    }
    if (newY > this.ClientSize.Height - pb.Height) {
	    newY = this.ClientSize.Height - pb.Height;
    }
	// New point to move it to
    Point newP = new Point(newX, newY);
