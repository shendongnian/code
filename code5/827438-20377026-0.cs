    int i = 0;
    Point p1, p2;
    void myPictureBox_MouseClick(object sender, MouseEventArgs e) {
      if(i == 1) this.myPictureBox.MouseClick -= myPictureBox_MouseClick;
      var point = new Point(e.X, e.Y);
      MessageBox.Show(string.Format("You've selected a pixel with coordinates: {0}:{1}", point.X, point.Y));
      if(i == 0) p1 = point;
      else p2 = point;
      i++;
    }
    //then use the two points p1,p2 for further processing.
