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
        protected override void OnMouseClick(MouseEventArgs e)
        {
             base.OnMouseClick(e);
             IDrawableObject clickedItem = _itemsToDraw.FirstOrDefault(x=> x.WasClicked(e.Location));
             if(clickedItem != null)
             {
                 //Do something with the clicked item.
             }
        }
    }
    
    interface IDrawableObject
    {
        void Draw(System.Drawing.Graphics g, Pen p);
        bool WasClicked(Point p)
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
        public bool WasClicked(Point p)
        {
             return p.X >= m_topLeft.X && p.X < m_topLeft.X + m_width 
                 && p.Y >= m_topLeft.Y && p.Y < m_topLeft.Y + m_height;
        }
    }
