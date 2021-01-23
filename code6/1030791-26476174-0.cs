    Console.Write("Item Number? ");
    num = Convert.ToInt32(Console.ReadLine());
    while (num != 0)
    {
    	// Do your seek operations here
    	// run this again so you won't be stuck in the loop
    	num = Convert.ToInt32(Console.ReadLine());
    }        {
            file.Seek(0, SeekOrigin.Begin);
            item = reader.ReadLine();
            Console.WriteLine(item);
        }
