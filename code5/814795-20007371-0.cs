    var e = document.Descendants("latitude").FirstOrDefault();
    
    double d = 0;
    int i = 0;
    
    if(double.TryParse(e.Value, out d))
    	i = (int)d;
    else
    	Console.WriteLine("{0} is not valid.", e.Value);
    
    Console.WriteLine("{0} is a double.", d);
    Console.WriteLine("{0} is a an int.", i);
