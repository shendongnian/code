    public class Direction
    {
        private Direction() { }
        public static readonly Direction Up = new Direction();
        public static readonly Direction Down = new Direction();
        public static readonly Direction Left = new Direction();
        public static readonly Direction Right = new Direction();
        public static Direction operator !(Direction direction)
        {
            if (direction == Direction.Up)
                return Direction.Down;
            else if (direction == Direction.Down)
                return Direction.Up;
            else if (direction == Direction.Left)
                return Direction.Right;
            else if (direction == Direction.Right)
                return Direction.Left;
        }
    }
