    class stationaryFood
    {
        public Texture2D CharacterImage { get; set; }
        public Rectangle Position { get; set; }
        public stationaryFood(Texture2D image, Rectangle position) {
            CharacterImage = image;
            Position = position;
        }
    }
