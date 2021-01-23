    interface ICommand { void Execute(); }
    class PlaceShip : ICommand
    {
        int x;
        int y;
        Ship ship;
        public PlaceShip(int x, int y, Ship ship)
        {
            // Initialize fields
        }
        public void Execute()
        {
            // Place the ship
        }
    }
    class Fire : ICommand
    {
        int x;
        int y;
        Player player;
        public Fire(int x, int y, Player player)
        {
            // Initialize fields
        }
        public void Execute()
        {
            // Try to hit enemy
        }
    }
