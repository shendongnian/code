      List<object> shapes = new List<object>(); 
      private void drawSquare(int x1, int y1, int x2, int y2)
      {
         shapes.Add(new Rectangle(x1, y1, x2, y2));
      }
      protected override void OnPaint(PaintEventArgs e)
      {
         base.OnPaint(e);
         Graphics g = e.Graphics;
         foreach (var shape in shapes)
         {
            if (shape is Rectangle)
            {
               g.DrawRectangle(new Pen(Color.Black), (Rectangle)shape);
            }
         }
      }
