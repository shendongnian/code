    class Program
    {
        static void Main(string[] args)
        {
            using (var container = new UserModelContainer())
            {
                var user = new User
                           {
                               FirstName = "Joe",
                               Surname = "Coder"
                           };
    
                var address = new Address
                              {
                                  AddressLine1 = "123 Any Street",
                                  AddressLine2 = "Apt 2A",
                                  City = "Anytown",
                                  StateProvince = "CA",
                                  PostalCode = "12345",
                                  Country = "United States",
                                  IsPublic = false
                              };
    
                user.Lookups.Add(address);
    
                container.SaveChanges();
            }
    
            using (var container = new UserModelContainer())
            {
                foreach (var user in container.Users)
                {
                    Console.WriteLine("Name: {0} {1}", user.FirstName, user.Surname);
    
                    foreach (var address in user.Lookups.OfType<Address>())
                    {
                        Console.WriteLine(address.AddressLine1);
                        Console.WriteLine(address.AddressLine2);
                        Console.WriteLine(address.City);
                        Console.WriteLine(address.StateProvince);
                        Console.WriteLine(address.PostalCode);
                        Console.WriteLine(address.Country);
                        Console.WriteLine("Address is {0}", address.IsPublic ? "Public" : "Private");
                    }
                }
            }
        }
    }
