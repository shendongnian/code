    [Flags]
    public enum DrawParts
    {
        Rectangles = 1,
        Circles = 2,
        Triangles = 4,
        //etc
    }
    public class A
    {
        //or a regular get/setter instead of a virtual property
        public virtual DrawParts DrawMode { get { return DrawParts.Rectangles | DrawParts.Circles; } } 
        public void Draw()
        {
            var mode = DrawMode;
            if (mode.HasFlag(DrawParts.Circles))
                DrawCircles();
            if (mode.HasFlag(DrawParts.Rectangles)) //NB, not elseif
                DrawRectangles();
            //etc
        }
    }
    public class B : A
    {
        public override DrawParts DrawMode{get{return DrawParts.Rectangles | DrawParts.Triangles; }}
    }
