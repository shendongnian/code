    public static class RectangleExtensions
    {
        public static Rectangle RectsGetBounds(this Rectangle rect, params Rectangle[] rects)
        {
            Rectangle rbase = rect;
    
            for (int i = 0; i < rects.Length; i++)
            {
                rbase = Rectangle.Union(rbase, rects[i]);
            }
    
            return rbase;
        }
    
        public static Rectangle ControlsGetBounds(this Control cntrl, params Control[] cntrls)
        {
            return RectsGetBounds(cntrl.Bounds, cntrls.Select(c => c.Bounds).ToArray());
        }
    }
