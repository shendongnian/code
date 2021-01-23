    public class Dealer
    {
        public int DealerId { get; set; }
        public string Name { get; set; }
    }
    public class Model
    {
        public int ModelId { get; set; }
        public string Name { get; set; }
        public Dealer Dealer { get; set; }
    }
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Model Model { get; set; }
    }
    public class Driver
    {
        public int DriverId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Customer Customer { get; set; }
    }
    public class DriverAddress
    {
        public int DriverAddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public Driver Driver { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var honda = new Dealer { DealerId = 1, Name = "Honda" };
            var ford = new Dealer { DealerId = 2, Name = "Ford" };
            var toyoto = new Dealer { DealerId = 3, Name = "Toyoto" };
            var volkswagen = new Dealer { DealerId = 4, Name = "Volkswagen" };
            var chevrolet = new Dealer { DealerId = 5, Name = "Chevrolet" };
            var civic = new Model { ModelId = 1, Name = "Civic", Dealer = honda };
            var fiesta = new Model { ModelId = 2, Name = "Fiesta", Dealer = ford };
            var corolla = new Model { ModelId = 3, Name = "Corolla", Dealer = toyoto };
            var passat = new Model { ModelId = 4, Name = "Passat", Dealer = volkswagen };
            var cruze = new Model { ModelId = 5, Name = "Cruze", Dealer = chevrolet };
            var magnus = new Customer { CustomerId = 1, FirstName = "Magnus", LastName = "Hedlund", Model = civic };
            var terry = new Customer { CustomerId = 2, FirstName = "Terry", LastName = "Adams", Model = fiesta };
            var charlotte = new Customer { CustomerId = 3, FirstName = "Charlotte", LastName = "Weiss", Model = corolla };
            var john = new Customer { CustomerId = 4, FirstName = "John", LastName = "Miller", Model = passat };
            var arlene = new Customer { CustomerId = 5, FirstName = "Arlene", LastName = "Huff", Model = cruze };
            var driver1 = new Driver { DriverId = 1, FirstName = "Fadi", LastName = "Fakhouri", Customer = magnus };
            var driver2 = new Driver { DriverId = 2, FirstName = "Hanying", LastName = "Feng", Customer = terry };
            var driver3 = new Driver { DriverId = 3, FirstName = "Cesar", LastName = "Garcia", Customer = charlotte };
            var driver4 = new Driver { DriverId = 4, FirstName = "Lint", LastName = "Tucker", Customer = magnus };
            var driver5 = new Driver { DriverId = 5, FirstName = "Robert", LastName = "Thomas", Customer = arlene };
            var driver6 = new Driver { DriverId = 6, FirstName = "David", LastName = "Adams", Customer = charlotte };
            var driver1Address = new DriverAddress { DriverAddressId = 1, AddressLine1 = "Main St", City = "Minnehaha", Zip = "57105", Driver = driver1 };
            var driver2Address = new DriverAddress { DriverAddressId = 2, AddressLine1 = "State St", City = "Los Angeles", Zip = "90034", Driver = driver2 };
            var driver3Address = new DriverAddress { DriverAddressId = 3, AddressLine1 = "Ralph St", City = "Winnebago", Zip = "61109", Driver = driver4 };
            List<Dealer> lstDealers = new List<Dealer> { honda, ford, toyoto, volkswagen, chevrolet };
            List<Model> lstModels = new List<Model> { civic, fiesta, corolla, passat, cruze };
            List<Customer> lstCustomers = new List<Customer> { magnus, terry, charlotte, john, arlene };
            List<Driver> lstDrivers = new List<Driver> { driver1, driver2, driver3, driver4, driver5, driver6 };
            List<DriverAddress> lstDriverAddress = new List<DriverAddress> { driver1Address, driver2Address, driver3Address };
            var result = from dealer in lstDealers
                         join model in lstModels on dealer.DealerId equals model.Dealer.DealerId
                         join customer in lstCustomers on model.ModelId equals customer.Model.ModelId
                         join driver in lstDrivers on customer.CustomerId equals driver.Customer.CustomerId into customerDriverGroup
                         from customerDriver in customerDriverGroup.DefaultIfEmpty(new Driver()) //defaultValue the empty constructor passed here
                         join address in lstDriverAddress on customerDriver.DriverId equals address.Driver.DriverId into driverAddressGroup
                         from driverAddress in driverAddressGroup.DefaultIfEmpty()
                         select new
                         {
                             Dealer = dealer,
                             Model = model,
                             Customer = customer,
                             Driver = customerDriver,
                             DriverAddress = driverAddress
                         };
            foreach (var v in result)
            {
                Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}{4}", v.Dealer.Name + ":",
                    v.Model.Name + ":", v.Customer.FirstName + ":", v.Driver == null ? String.Empty : v.Driver.FirstName
                    + ":", v.DriverAddress == null ? string.Empty : v.DriverAddress.City);
            }
            Console.Read();
        }
    }
