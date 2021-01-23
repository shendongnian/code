    static Phone GetPhone()
    {
        Phone phone = new Phone(); 
        Console.Write("Enter the phone manufacturer: ");
        phone.Manufacturer = Console.ReadLine();
        Console.Write("Enter the phone model: ");
        phone.Model = Console.ReadLine();
        Console.Write("Is it cordless? [Y or N]: ");
        phone.HasCord = Console.ReadLine().ToUpper() == "Y";
        Console.Write("Enter the phone price: ");
        phone.Price = Convert.ToDouble(Console.ReadLine());
        return phone; 
    }
    static void DisplayPhones(List<Phone> phones)
    {
        for (int i = 0; i < phones.Count; i++)
        {
            Console.WriteLine("==Phone #{0}==", i);
            Console.WriteLine("Phone Manufacturer: {0}", phones[i].Manufacturer);
            Console.WriteLine("Phone Model: {0}", phones[i].Model);
            Console.WriteLine("Has Cord: {0}", phones[i].HasCord ? "Yes" : "No");
            Console.WriteLine("Phone Price: {0}", phones[i].Price);
        }
        Console.WriteLine("Number of phones entered: {0}", phones.Count);
    }
    static void Main(string[] args)
    {
        List<Phone> phones = new List<Phone>(); 
        bool shouldContinue = true;
        do
        {
            phones.Add(GetPhone());
            Console.Write("Would like to process another phone? [Y or N]: ", shouldContinue);
            shouldContinue = Console.ReadLine().ToUpper() == "Y";
        } while (shouldContinue == true);
        if (shouldContinue == false)
        {
            DisplayPhones(phones);
        }
    }
