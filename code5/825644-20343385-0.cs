        private void pictuerBox_Paint(object sender, PaintEventArgs e)
        {
             if(IsDrawRect) // Flag Variable to check if need to draw rect
                  {
                    Rectangle RectMark = new Rectangle(startX,StartY,Hieght,Widht); // your location to draw
                    e.Graphics.DrawRectangle(new Pen(Color.Red, 1), RectMark);
                   }
        }
