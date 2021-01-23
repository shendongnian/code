    class Unit
    {
        // add the stats like name , health, speed and strength.
        public Stats stats { get; private set; }
        // add the location coordinates
        public Location location { get; private set; }
    
        public Unit()
        {
            location = new Location();
            stats = new Stats();
        }
    }
