    if (this.ClientRectangle.Contains(rc.BoundingBox.Inflate(step, step))) {
        rc.MoveXForward();
    } else {
        MessageBox.Show("Game over");
    }
---
    public class MyRcClass
    {
       ...
       public Rectangle BoundingBox
       {
           get { return new Rectangle(PositionX, PositionY, Width, Height); }
       }
    }
