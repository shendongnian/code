    public class Canvas : Control
    {
        public Canvas()
        {
            this.SetStyle( ControlStyles.AllPaintingInWmPaint, true );
            this.SetStyle( ControlStyles.OptimizedDoubleBuffer, true );
            this.SetStyle( ControlStyles.UserPaint, true );
            this.SetStyle( ControlStyles.ResizeRedraw, true );
        }
    }
