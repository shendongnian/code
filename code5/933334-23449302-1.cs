    public abstract class GameObject
    {
        private BlockType _buildingBlocks[,];
        private int x0, y0, x1, y1; // First indexes and last indexes+1 used in array.
        // Pixel coordinates
        public Point Location { get; set; }
        // Represents the current position anbd size.
        public Rectangle BoundingBox
        { 
            get {
                return new Rectangle(
                    Location.X + BlockSize * x0,
                    Location.Y + BlockSize * y0,
                    BlockSize * (x1 - x0),
                    BlockSize * (y1 - y0)
                );
            } 
        }
        public void Draw(Graphics g, int x, int x)
        {
            for (int i = x0; i < x1; i++) {
                for (int j = y0; j < y1; j++) {
                    BlockType block = _buildingBlocks[i, j];
                    if (block != null) {
                        g.FillRectangle(block.Brush,
                                        x + BlockSize * i, y + BlockSize * j,
                                        BlockSize, BlockSize);
                    }
                }
            }
        }
        protected void CalculateBounds()
        {
            x0 = _buildingBlocks.GetLength(0);
            y0 = _buildingBlocks.GetLength(1);
            x1 = 0;
            y1 = 0;
            for (int i = 0; i < _buildingBlocks.GetLength(0); i++) {
                for (int j = 0; j < _buildingBlocks.GetLength(1); j++) {
                    if (buildingBlocks[i, j] != null) {
                       x0 = Math.Min(x0, i);
                       y0 = Math.Min(y0, j);
                       x1 = Math.Max(x1, i + 1);
                       y1 = Math.Max(y1, j + 1);
                    }
                }
            }
        } 
    }
