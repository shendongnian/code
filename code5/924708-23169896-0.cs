    public class Apartment
    {
        public Apartment()
        {
            // set default values
        }
        // define properties
        public int NumberOfBedRooms { get; set; }
        // ...
    }
    var apt = new Apartment {
      ApartmentSize = 100,
      NumberOfBedrooms = 3,
      NumberOfShowers = 2,
      CurrentMarketValue = 100000m,
      PurchasePrice = 100000m
    }
