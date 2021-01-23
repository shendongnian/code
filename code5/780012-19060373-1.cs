    public struct Rectangle
    {    
        private readonly int x, y, width, height;
        public int X { get { return x; } }
        public int Y { get { return y; } }
        public int Width { get { return width; } }
        public int Height{ get { return height; } }
        public Rectangle(int x, int y, int width, int height)
        {
            this.x = x; 
            this.y = y; 
            this.width = width; 
            this.height = height;
        }
    }
