    Console.Write("Enter HEX: ");
    string hexValues = Console.ReadLine();
    string[] hexValuesSplit = hexValues.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    Console.WriteLine("HEX = DECIMAL");
    foreach (String hex in hexValuesSplit)
    {
        // Convert the number expressed in base-16 to an integer. 
        int value = Convert.ToInt32(hex, 16);
        Console.WriteLine(string.Format("{0} = {1}", hex, Convert.ToDecimal(value)));
    }
    Console.ReadKey();
