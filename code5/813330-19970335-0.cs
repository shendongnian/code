    string foo = "Hello";
    string bar = String.Format("{0, 7}", foo);
    Console.WriteLine("'{0}'", bar); 
    
    bar = String.Format("{0, -7}", foo);
    Console.WriteLine("'{0}'", bar); 
