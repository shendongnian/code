    private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            int maxX = 100;
            int minX = 10;
            int maxY = 20;
            int minY = 5;
                if ((MousePosition.X < maxX) && (MousePosition.X > minX)
                     && (MousePosition.Y > minY) && (MousePosition.Y < maxY))
                {
                    //do something
                }
            }
