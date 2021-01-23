    static void AddNew(CustomerStruct[] _NewCustomer)
    {
    Console.Clear();
    using (StreamWriter sw = new StreamWriter(@"..\..\..\Files\Customer.txt", true))
    {
        Console.Write("\n\n Enter Customer Number: ");
        sw.WriteLine(_NewCustomer[RecCount].CustomerNo=Console.ReadLine());
        Console.Write("\n\n Enter Customer Surname: ");
        sw.WriteLine(_NewCustomer[RecCount].Surname=Console.ReadLine());
        Console.Write("\n\n Enter Customer Forname: ");
        sw.WriteLine(_NewCustomer[RecCount].Forename=Console.ReadLine());
        Console.Write("\n\n Enter Customer Street address: ");
        sw.WriteLine(_NewCustomer[RecCount].Street=Console.ReadLine());
        Console.Write("\n\n Enter Customer Town: ");
        sw.WriteLine(_NewCustomer[RecCount].Town=Console.ReadLine());
        Console.Write("\n\n Enter Customer DOB: ");
        sw.WriteLine(_NewCustomer[RecCount].DOB=Console.ReadLine());
        RecCount++;
    }
    Console.ReadLine();
    }
