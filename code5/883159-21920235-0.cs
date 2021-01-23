    class Station
    {
        public string Name { get; set; }
        public decimal Lng { get; set; }
        public decimal Lat { get; set; }
        public Station(string name, decimal longitude, decimal latitude)
        {
            this.Name = name;
            this.Lng = longitude;
            this.Lat = latitude;
        }
    }
