    double val;
    
    if(double.TryParse(values8[x], out val))
    {
         Console.WriteLine("Parsing successful");
    }
    else
    {
       Console.WriteLine("Parsing failed");
    }
