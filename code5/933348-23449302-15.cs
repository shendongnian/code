    public abstract class GameObject
    {
        protected BlockType[,] _buildingBlocks; // The 2-d array. Replace "BlockType" 
                                                // by the type you are using.
        protected int _x0, _y0; // Indexes of the first non empty block.
        protected int _x1, _y1; // Indexes of the last  non empty block + 1.
        // Pixel coordinates of upper left corner of the intact game object.
        public Point Location { get; set; }
        // Represents the current position and size of the possibly diminished
        // game object in pixels.
        public Rectangle BoundingBox
        { 
            get {
                return new Rectangle(
                    Location.X + BlockSize * _x0,
                    Location.Y + BlockSize * _y0,
                    BlockSize * (_x1 - _x0),
                    BlockSize * (_y1 - _y0)
                );
            } 
        }
        public void Draw(Graphics g, int x, int x)
        {
            for (int i = _x0; i < _x1; i++) {
                for (int j = _y0; j < _y1; j++) {
                    BlockType block = _buildingBlocks[i, j];
                    if (block != null) {
                        // Replace by the appropriate drawing methods for XNA.
                        g.FillRectangle(block.Brush,
                                        x + BlockSize * i, y + BlockSize * j,
                                        BlockSize, BlockSize);
                    }
                }
            }
        }
        // Call this after changes have been made to the arrray which may affect the
        // apparent size of the game object, e.g. after the object was hit by a bomb.
        protected void CalculateBounds()
        {
            _x0 = _buildingBlocks.GetLength(0);
            _y0 = _buildingBlocks.GetLength(1);
            _x1 = 0;
            _y1 = 0;
            for (int i = 0; i < _buildingBlocks.GetLength(0); i++) {
                for (int j = 0; j < _buildingBlocks.GetLength(1); j++) {
                    if (buildingBlocks[i, j] != null) {
                       _x0 = Math.Min(_x0, i);
                       _y0 = Math.Min(_y0, j);
                       _x1 = Math.Max(_x1, i + 1);
                       _y1 = Math.Max(_y1, j + 1);
                    }
                }
            }
        }
        public void DestroyBlocksAt(IEnumerable<Point> points)
        {
            //TODO: destroy hit blocks.
            CalculateBounds();
        }
    }
