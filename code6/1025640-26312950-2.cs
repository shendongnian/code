    Console.WriteLine("Please enter a number");
    try
    {
    int num = Convert.ToInt32(Console.ReadLine());
    }
    //if someone enter a `string` in place of Integer, it will cause
    catch(InvalidFormatException ix) 
    {
    }
    catch(Exception ex)
    {
    }
