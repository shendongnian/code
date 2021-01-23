    if (Console.ReadLine().Length == 5)
        {
            temp = int.Parse(Console.ReadLine());
            address.zipCode = temp;
        }
    else{
    while (Console.ReadLine().Length != 5)
    {
        Console.WriteLine("Error. Zip code is not 5 digits. Please enter a valid number.");
        temp = int.Parse(Console.ReadLine());
        }
    }
