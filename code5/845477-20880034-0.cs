    public class HotelGridViewModel
    {
        public string Code3{get;set;}
        public string Hotel3{get;set;}
    }
    var query15 = (from g in dc.Fix_Hotel_TTVs
               from f in dc.Hotel_Meals_TBLs
               where g.CityCode == "KEP" && g.MarketID == "IT" && g.Category == "DEL" && g.HotelCodeID == f.HotelCodeID
               select new HotelGridViewModel() { Code3 = f.WholeCode, Hotel3 = f.HotelName 
               ).DefaultIfEmpty(new HotelGridViewModel(){ Code3 = "No  Data", Hotel3 = "No Data"});
