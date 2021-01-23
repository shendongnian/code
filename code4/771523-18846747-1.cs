    public class Tile
    {
        public string Msg { get; set; }
        public Uri Image { get; set; }
    }
    
    public class LiveTileData
    {
        public LiveTileData()
        {
            tileData.Add(new Tile { Msg = "Stack Overflow", Image = new Uri("http://jenswinter.com/image.axd?picture=stackoverflow-logo-250.png") });
            tileData.Add(new Tile { Msg = "Super User", Image = new Uri("http://superuser.com/content/superuser/img/logo.png") });
        }
        private static ObservableCollection<Tile> tileData = new ObservableCollection<Tile>();
        public static ObservableCollection<Tile> TileData
        {
            get
            {
                return tileData;
            }
        }
    }
