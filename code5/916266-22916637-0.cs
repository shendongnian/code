    public partial class SiteBookingsTable
    {
        public int listID { get; set; }
        public string departureAirport { get; set; }  
        public string chooseDepartureAirport { get; set; }     
        public IEnumerable<SelectListItem> selectDeparture { get; set; }
    }
