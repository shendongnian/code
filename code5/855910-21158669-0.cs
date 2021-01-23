    var temp = Console.ReadLine();
    while (temp.Length > 5)
    {
        Console.WriteLine("Error. Zip code is not 5 digits. Please enter a valid number.");
        temp = Console.ReadLine(); 
    }
    address.zipCode = int.Parse(temp);
