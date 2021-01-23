    private void loadDrawing(){
      Bitmap map = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
      var graph = Graphics.FromImage(map);
      graph.DrawRectangle(new Pen(Color.Blue, 3), 0, 0, 50, 50);
      pictureBox1.Image = map;
    }
