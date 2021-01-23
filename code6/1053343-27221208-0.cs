    public YourControl : Control
    {
        List<IDrawableObject> _itemsToDraw = new List<IDrawableObject>();
        
        protected override void Draw(System.Drawing.Graphics g, Pen p)
        {
            foreach(var item in _itemsToDraw)
            {
                item.Draw(g, p);
            }
        }
    }
    
    interface IDrawableObject
    {
        void Draw(System.Drawing.Graphics g, Pen p);
    }
    
    private class Ellipse : IDrawableObject
    {    
        Point m_topleft;
        int m_width;
        int m_height;
    
        //Snip stuff like constructors assigning the values to the private fields.
    
        public void Draw(System.Drawing.Graphics g, Pen p)
        {
            g.DrawEllipse(p, m_topLeft.X, m_topLeft.Y, m_width, m_height);
        }
    }
