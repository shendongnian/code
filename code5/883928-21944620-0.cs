    if (this.ClientRectangle.Contains(rc.Rectangle)) {
        rc.MoveXForward();
    } else {
        MessageBox.Show("Game over");
    }
---
    public class MyRcClass
    {
       ...
       public Rectangle Rectangle
       {
           get { return new Rectangle(PositionX, PositionY, Width, Height); }
       }
    }
