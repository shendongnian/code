    private void pictureBox_Paint(object sender, PaintEventArgs e) {
    	PictureBox pb = sender as PictureBox;
    	if (pb == null) {
    		return;
    	}
    	Pen p = new Pen(Brushes.Red);
    	e.Graphics.DrawLine(p, new Point(pb.Width / 2, 0), new Point(pb.Width / 2, pb.Height));
    }
