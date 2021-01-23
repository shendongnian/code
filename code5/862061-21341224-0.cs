    class Phone
    {
        // Property to store the fields of a Phone object
        public string Manifacturer {get;set;}
        public string Model {get;set;}
        public string IsCordless {get;set;}
        public decimal Price {get;set;}
    
        // No parameters to pass, but returns a Phone instance 
        static Phone inputPhone()
        {
            Phone p = new Phone();
            Console.Write("Enter the phone manufacturer: ");
            p.Manufacturer = Console.ReadLine();
            Console.Write("Enter the phone model: ");
            p.Model = Console.ReadLine();
            Console.Write("Is it cordless? [Y or N]: ");
            p.IsCordless = Console.ReadLine().ToUpper() == "Y";
            Console.Write("Enter the phone price: ");
            p.Price = Convert.ToDecimal(Console.ReadLine());
            return p;
        }
        // Pass the list and loop on every element    
        static void outputPhones(List<Phone> pList)
        {
            foreach (Phone o in pList)
            {
                Console.WriteLine("Phone Manufacturer: {0}", p.Manufacturer);
                Console.WriteLine("Phone Model: {0}", p.Model);
                Console.WriteLine("Has Cord: {0}", p.IsCordless ? "Yes" : "No");
                Console.WriteLine("Phone Price: {0}", p.Price);
            }
            Console.WriteLine("Number of phones entered: {0}", pList.Count);
        }
    
        static void Main(string[] args)
        {
            // Initialize an empty Phone list
            List<Phone> pList = new List<Phone>();
            bool continueLoop = true;
    
            do
            {
                // Get the input from the user and add to the list
                Phone p = inputPhone();
                pList.Add(p);
                Console.Write("Would like to process another phone? [Y or N]: ", continueLoop);
                continueLoop = Console.ReadLine().ToUpper() == "Y";
            } while (continueLoop == true);
            // output the list    
            outputPhones(pList);
    
        }
    }
