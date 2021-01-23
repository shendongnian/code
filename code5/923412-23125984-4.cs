    private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            int maxX = 1000;
            int minX = 5;
            int maxY = 1000;
            int minY = 5;
                if ((MousePosition.X < maxX) && (MousePosition.X > minX)
                     && (MousePosition.Y > minY) && (MousePosition.Y < maxY))
                {
                    //do something
                }
            }
