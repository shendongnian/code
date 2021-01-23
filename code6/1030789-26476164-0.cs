    Console.Write("Item Number? ");
    num = Convert.ToInt32(Console.ReadLine());
    while (num != 0)
    {
        file.Seek(0, SeekOrigin.Begin);
        item = reader.ReadLine();
        Console.WriteLine(item);
    }
