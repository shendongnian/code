        static float m;
        static float n;
        static float o;
        static float p;
        static float TotalBeforeTax;
        static void Main(string[] args)
        {
    
            Console.WriteLine("Welcome to  Infinate Happiness Ranch.\nPlease enter your order information bellow. ");
    
            Console.WriteLine();
    
            Console.WriteLine("Please enter your first and last name:");
            string FirstName = Console.ReadLine();
    
            Console.WriteLine("Please enter your street address:");
            string Address = Console.ReadLine();
    
            Console.WriteLine("Please enter your city:");
            string City = Console.ReadLine();
    
            Console.WriteLine("Please enter your two letter state abreviation:");
            string StateCode = Console.ReadLine();
    
            Console.WriteLine("Please enter your zip code:");
            string ZipCode = Console.ReadLine();
    
            Console.WriteLine("Please enter the number of Tribbles \nyou wish to purchase for $29.99 plus tax");
            string NumberOrdered = Console.ReadLine();
    
    
    
            Console.WriteLine("Invoice \nName {0}", FirstName);
            Console.WriteLine("Address {0}", Address);
            Console.WriteLine("City {0}", City);
            Console.WriteLine("StateCode {0}", StateCode);
            Console.WriteLine("ZipCode {0}", ZipCode);
            Console.WriteLine("NumberOrdered {0}", NumberOrdered);
            //PROGRAM WORKS UNTIL HERE ? HELP ? ? ? ? ?
            //NumberOrdered = m;
            m = float.Parse(NumberOrdered);
            TotalBeforeTax = m * 29.99f; //'n' is total b4 tax
            n = TotalBeforeTax;
            o = n * 0.9f;//'o' is total tax due
            p = o + n; //'p' is total due
    
            Console.WriteLine("Your total is {0}", n);
            Console.WriteLine("Your tax is {0}", o);
            Console.WriteLine("Your total charge is {0}", p);
            Console.WriteLine("Thank you for your order");
            Console.WriteLine();
    
    
    
    
    
    
    
    
    
            //Console.WriteLine("Name:" + FirstName);
            Console.Read();
    
    
    
        }
        
