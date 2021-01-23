    class Level
    {
        public int Boxes { get; set; }
        public int MaxPoints { get; set; }
        public int Health { get; set; }
        public int[,] SolidBoxes()
        {
            int[,] position = new int[boardSize, boardSize];
            position[1, 1] = 1;
            return position;
        }
    }
