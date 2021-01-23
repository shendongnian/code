    Console.WriteLine("Enter the the zip code of the contact.");
    do
    {
        temp = int.Parse(Console.ReadLine());
        if (temp.Length!=5)
        {
            Console.WriteLine("Error. Zip code is not 5 digits. Please enter a valid number.");
        }
        else
        {
            address.zipCode = temp;
        }
    } while(temp.Length!=5);
