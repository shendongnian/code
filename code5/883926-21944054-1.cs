    private void CollisionXForward()
    {
        rc.MoveXForward();
        //if the position of x-axis of the rectangle goes over the limit of the form...
        if (rc.PositionX + rc.Width >= ClientRectangle.Width )
        {
           //...game over
            MessageBox.Show("Game over");
        }
    }
