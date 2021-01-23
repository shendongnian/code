     static void Main(string[] args)
        {
    
            List<Customer> customers = new List<Customer>;
    
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Enter A Customer:");
                Customer customer = new Customer(); // create new object
                customer.Name = Console.ReadLine();  // set name Property
                Console.WriteLine("Enter {0} Insurance Value (numbers only):", Name);
                customer.Value = Convert.ToDouble(Console.ReadLine());// set Value Property
                customers.Add(customer); // add customer to List
            }
    
    
            Console.ReadLine();
        }
