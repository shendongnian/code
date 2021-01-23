    public void SetPixel(PointF p, Color c, Graphics g){
      using(Brush brush = new SolidBrush(c)){
        e.Graphics.FillRectangle(brush, new RectangleF(p, new Size(1, 1)));
      }
    }
    //Paint event handler of your form
    private void Form1_Paint(object sender, PaintEventArgs e){
       SetPixel(yourPoint, Color.Red, e.Graphics);
    }
