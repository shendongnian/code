    public int MoveYUpWard()
    {
        PositionY -= 10;
        return PositionY;
    }
    public int MoveYDownWard()
    {
        PositionY += 10;
        return PositionY;
    }
    private void Form1_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Up)
        {
            MessageBox.Show("UP");
            //Sets position y to 100
            rc.MoveYUpWard();
            this.Invalidate();
        }
    }
