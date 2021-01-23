    public class MyRectangle
    {
        private System.Drawing.Rectangle rect;
    
        public MyRectangle(int x, int y, int width, int height)
        {
            this.rect = new System.Drawing.Rectangle(x, y, width, height);
        }
    
        public int X
        {
            get
            {
                return rect.X;
            }
    
            set
            {
                this.rect = new System.Drawing.Rectangle(value, rect.Y, rect.Width, rect.Height);
            }
        }
    
        public int Y
        {
            get
            {
                return rect.Y;
            }
    
            set
            {
                this.rect = new System.Drawing.Rectangle(rect.X, value, rect.Width, rect.Height);
            }
        }
    
        public int Width
        {
            get
            {
                return rect.Width;
            }
    
            set
            {
                this.rect = new System.Drawing.Rectangle(rect.X, rect.Y, value, rect.Height);
            }
        }
    
        public int Height
        {
            get
            {
                return rect.Height;
            }
    
            set
            {
                this.rect = new System.Drawing.Rectangle(rect.X, rect.Y, rect.Width, value);
            }
        }
    
        public System.Drawing.Rectangle Rectangle
        {
            get
            {
                return rect;
            }
        }
    }
