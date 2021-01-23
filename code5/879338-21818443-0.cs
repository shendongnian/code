    public class Customer
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public double AccountNumber { get; set; }
            public double AvaliableBalance { get; set; }
    
            public void Buy(Phone phone)
            {
                if (phone == null)
                    return;
                var phoneService = new PhoneOrderService();
    
                if (phoneService.PurchasePhone(this, phone.Model))
                {
                    Console.WriteLine("{0} phone purchased!", phone.Model);
                }
            }
    namespace PhoneApp
    {
        public enum PhoneType : int
        {
            Apple,
            Windows, 
            Samsung
        }
    
    
        public class Phone
        {
            public string Brand { get;  set; }
           public string Model { get;  set; }
           public double Price { get; set; }
           public int QuantityInStock { get; set; }
           public PhoneType PhoneType { get; set; }
            
        }
    }
    namespace PhoneApp
    {
        public class PhoneOrderService
        {
            // I used a private static list here as a backup storeage for ease of 
            // implementation and simplicity of the example.
            private static List<Phone> _itemsInStock  = new List<Phone>();
    
            public void AddToStock(Phone phone)
            {
                if(phone == null)
                    return;
    
                _itemsInStock.Add(phone);
            }
    
            //Now add those methods in your apple model to this service.
    
            public bool PurchasePhone(Customer customer, string model)
            {
                if (customer == null)
                    return false;
    
                if (string.IsNullOrWhiteSpace(model))
                    return false;
    
                var phone = _itemsInStock.FirstOrDefault(a => a.Model == model);
    
    
                if (phone != null)
                {
                    if (customer.AvaliableBalance < phone.Price)
                        return false;
                    customer.AvaliableBalance -= phone.Price;
    
                    phone.QuantityInStock -= 1;    
    
                    AddToStock(phone);
                }
    
                // then you use the phone to do whatever you like
                //after return true to the calling method to show that this action ucceeded.
    
                return true;
            }
        }
    }
    namespace PhoneApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                //initialize the PhoneOrderService
                var phoneOrderService = new PhoneOrderService();
                
                //initialize the phone model
                var phone1 = new Phone
                {
                    Model = "IPhone 5",
                    Price = 450,
                    QuantityInStock = 5,
                    Brand = "Brand new",
                    PhoneType = PhoneType.Apple
                };
    
                //initialize the phone model
                var phone2 = new Phone
                {
                    Model = "Nokia Lumia",
                    Price = 500,
                    QuantityInStock = 3,
                    Brand = "Brand new",
                    PhoneType = PhoneType.Windows
                };
    
                //initialize the phone model
                var phone3 = new Phone
                {
                    Model = "Galaxy 4 tab",
                    Price = 350,
                    QuantityInStock = 7,
                    Brand = "Brand new",
                    PhoneType = PhoneType.Samsung
                };
    
                //Add the phones to the phone order service
                phoneOrderService.AddToStock(phone1);
                phoneOrderService.AddToStock(phone2);
                phoneOrderService.AddToStock(phone3);
    
    
                //Initialize the customer model
                var customer = new Customer
                {
                    Name = "Mr Moon",
                    AvaliableBalance = 1000,
                    Address = "41 new street road!",
                    AccountNumber = 1234567889
                };
    
                customer.Buy(phone1);
    
                Console.ReadLine();
            }
        }
    }
