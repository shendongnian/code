    public class Car
    {
        public string CarName { get; set; }
        public string SystemId { get; set; }
    }
    public class CarRent : Car
    {
        public DateTime RentEndDate { get; set; }
    }
    
    public class CarPurchase : Car
    {
        public decimal Mileage { get; set; }
    }
