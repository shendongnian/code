    try
    {
        mnth=0;
        mnth = Int32.Parse(Console.ReadLine());
        if (mnth > 12 || mnth < 0)
        {
            Console.Write("----Incorrect Month...plz Re-");
            lp_val = 1;
        }
    }
    catch (FormatException ee) 
    {
        Console.WriteLine(ee.Message);
    }
