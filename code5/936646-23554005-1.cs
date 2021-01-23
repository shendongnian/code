            double amount;
            /* Dont need to declare these explicitly!            
            double USD = 1.39;
            double GBP = .82;
            double CHF = 1.22;
            double AUD = 1.48;
            double CAD = 1.51;*/
            string currency;
            Dictionary<string, double> factors = new Dictionary<string, double>();
            factors.Add("GBP", 0.82D);
            factors.Add("USD", 1.39D);
            // ... add other factors
            Console.WriteLine("Please enter the amount of Euro you wish to be converted:");
            amount = double.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Please choose the currency you wish to convert to:");
            Console.WriteLine("USD");
            Console.WriteLine("GBP");
            Console.WriteLine("CHF");
            Console.WriteLine("AUD");
            Console.WriteLine("CAD");
            Console.WriteLine("");
            currency = Console.ReadLine();
            
            double factor;
            if (factors.TryGetValue(currency, out factor))
            {
                Console.WriteLine("You have entered {0} EUR which converts to {1} {2}", amount, amount * factor, currency);
            }
            else
            {
                Console.WriteLine("You did not enter a recognised currency {1}", currency);
            }
