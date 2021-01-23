    public class MyContainer : Panel {
      public override Rectangle DisplayRectangle {
        get {
          int headerHeight = 25;
          return new Rectangle(
            this.Padding.Left,
            this.Padding.Top + headerHeight,
            this.ClientSize.Width - 
              (this.Padding.Left + this.Padding.Right),
            this.ClientSize.Height - 
              (this.Padding.Top + this.Padding.Bottom + headerHeight));
        }
      }
    }
