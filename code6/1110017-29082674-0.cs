    public class VarientItemsPlaceHolder
    {
         public string FlightID;
         public string FlightBackID;
    }
    
    public class OuterJsonObject
    {
          public List<PricesViewModel.DepartureFlightsData> PriceItems;
          public List<VarientItemsPlaceHolder> VarientItems;
          public strint Error;
    }
    
    // deserialize the whole thing first
    List<OuterJsonObject> everything = JsonConvert.DeserializeObject<OuterJsonObject>(File.ReadAllText(url));
    
    // flatten the Lists of PricesViewModel.DepartureFlightsData into one master List<PricesViewModel.DepartureFlightsData>
    
    List<PricesViewModel.DepartureFlightsData> allFlights = everything.SelectMany(x => x.PricedItems).ToList();
    
    
    // filter the master list using cityfromcode, citytocode, airlinecode
    List<PricesViewModel.DepartureFlightsData> filteredFlights = allFlights.Where(x => x.CityFromID == cityfromcode && x.CityToID == citytocode && x.AirlineCode == airlinecode).ToList();
