    int result;
    object a = 5;
    if(int.TryParse(a.ToString(),out result))
    {
       Console.WriteLine("value is parsed");  //will print 5
    }    
    object b = a5;
    if(int.TryParse(b.ToString(),out result))
    {
        Console.WriteLine("value is parsed");  
    }
    else
    {
        Console.WriteLine("input is not a valid integer");  //will print this   
    }
