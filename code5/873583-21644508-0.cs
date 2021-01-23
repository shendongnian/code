    public class MapLocationCompany
    {
        [Key]
        public int id { get; set; }
        [HiddenInputAttribute]
        public string UserName { get; set; }
        public string CompanyName { get; set; }
        public double MapStartupLatitude { get; set; }
        public double MapStartupLongitude { get; set; }
        public int MapInitialZoomIn { get; set; }
        public List<MapLocation> MapLocationList { get; set; }
    
        public void MapLocationCompany()
        {
            MapLocationList = new List<MapLocation>();
        }
    }
