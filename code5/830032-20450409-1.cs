    while (itm.item == null)
    {
        Console.WriteLine("Enter the code :");
        itm.item = searchItem(Convert.ToInt32(Console.ReadLine()));
        if (itm.item == null)
        {
            Console.WriteLine("Item not found. Try again.");
        }
    }
