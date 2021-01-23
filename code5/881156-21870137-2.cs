    int posx, posy;
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        canMove = true;
        posx = MousePosition.X;
        posy = MousePosition.Y;
    }
    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        if (canMove == 1 && (posx != MousePosition.X || posy != MousePosition.Y)) {
            MoveForm();
        }
        posx = MousePosition.X;
        posy = MousePosition.Y;
    }
