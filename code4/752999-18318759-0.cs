    MyClass 
    { 
        Rectangle _rect;
        public Rectangle rect { get { return _rect; } set { _rect = value; } }
        
        public void AddWidth(int width)
        {
            rect = new Rectangle(rect.X, rect.Y, rect.Width + width, rect.Height);
        }
    }
