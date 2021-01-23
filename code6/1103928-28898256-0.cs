    private void Form1_KeyDown(object sender, KeyEventArgs e)   
        {
            if (isMoving == true)
            {
                if (e.KeyCode == Keys.Up)
                {
                    _y -= 10;
                    Invalidate();
                }
                if (e.KeyCode == Keys.Down)
                {
                    _x -= 10;
                    Invalidate();
                }
            }     
        }
