    class ShipItem
    {
        public enum ShipTypes { BattleShip, Carrier, Destroyer, Submarine, Frigate };
            
        public ShipTypes Ship { get; set; }
        public string Name { get; set; }
        
        public ShipItem(string n, ShipTypes st)
        {
            Name = n;
            Ship = st;
        }
        public override string ToString()
        {
            return String.Format("{0}: {1}", Ship.ToString(), Name);
        }
    }
