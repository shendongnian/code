    private void CollisionXForward()
    {
        //if the position of x-axis of the rectangle goes over the limit of the form...
        if (rc.PositionX + step + rc.Width >= ClientRectangle.Width ) //step is 5 in your case
        {
           //...game over
            MessageBox.Show("Game over");
        }
        else
        {
            //move the object +5 every time i press right arrow
            rc.MoveXForward();
        }
    }
