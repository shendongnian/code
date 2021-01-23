        static void Main(string[] args)
        {
            string name, address, country;
            short age;
            person one = new person();
            do
            {
                Console.Write("Name: ");
                name = Console.ReadLine();
                Console.Write("Age: ");
                Int16.TryParse(Console.ReadLine(), out age);
                Console.Write("Address: ");
                address = Console.ReadLine();
                Console.Write("Country: ");
                country = Console.ReadLine();
            } while (name == "" || address == "" || country == "" || age < 1);
            one.setInfo(ref name, ref age, ref address, ref country);
            one.getInfo();
            Console.ReadKey();
        }
