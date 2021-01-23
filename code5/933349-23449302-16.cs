    public class Invader : GameObject
    {
        private const int WIDTH = 10, HEIGHT = 7; // Width and height of invader in blocks.
        public Invader()
        {
            _buildingBlocks = new BlockType[WIDTH, HEIGHT];
            _x1 = WIDTH;
            _y1 = HEIGHT;
            _buildingBlocks[0, 0] = ...
            ...
        }
    }
