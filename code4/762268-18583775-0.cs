    Console.Write("Enter interval in MS : ");
    while (!int.TryParse(Console.ReadLine(), out TO))
          Console.Write("The value must be of integer type, try again: ");
    
    Console.Write("Enter number of threads to use : ");
    while (!int.TryParse(Console.ReadLine(), out threads))
          Console.Write("The value must be of integer type, try again: ");
    ipe1 = new IPEndPoint(IPAddress.Parse(ip), Convert.ToInt32(port));
