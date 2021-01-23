    Regex pattern = new Regex(@"^\w+([-+.']\w+)*@(?=.*[a-zA-Z])\w+([-.]\w+)*\.\w+([-.]\w+)*$");
    
    Console.WriteLine( pattern.IsMatch("name@mailinator.com"));
    => True
    
    Console.WriteLine( pattern.IsMatch("test@192.123.12.1"));
    => False
