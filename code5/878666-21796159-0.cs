    internal class Program
        {
            private static void Main(string[] args)
            {
                var customerRepo = new Repository<Customer>(new Customer());
                var userRepo = new Repository<User>(new User());
    
                customerRepo.Update(new Customer
                                        {
                                            DateOfBirth = DateTime.Now,
                                            FirstName = "Customer",
                                            LastName = "Cust",
                                            NumberOfOrders = 3
                                        });
                userRepo.Update(new User
                                    {
                                        DateOfBirth = DateTime.Now,
                                        FirstName = "User",
                                        LastName = "Us"
                                    });
                userRepo.Show();
                customerRepo.Show();
                Console.ReadKey();
            }
    
    
            public class Repository<T>
            {
                private T _entity;
    
                public Repository(T entity)
                {
                    _entity = entity;
                }
    
                public void Update(T data)
                {
                    Mapper.CreateMap<T, T>();
                    Mapper.DynamicMap(data, _entity);
                }
    
                public void Show()
                {
                    Console.WriteLine(_entity.ToString());
                }
            }
    
            public class Customer
            {
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public DateTime DateOfBirth { get; set; }
    
                public int NumberOfOrders { get; set; }
    
                public override string ToString()
                {
                    return GetType().Name + "= " + FirstName + " " + LastName + " " + DateOfBirth + " " + NumberOfOrders;
                }
            }
    
            public class User
            {
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public DateTime DateOfBirth { get; set; }
    
                public override string ToString()
                {
                    return GetType().Name + "= " + FirstName + " " + LastName + " " + DateOfBirth;
                }
            }
        }
