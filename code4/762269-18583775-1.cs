    int port;
    IPAddress ip;
    Console.Write("Enter IP : ");
    while (!int.TryParse(Console.ReadLine(), out ip))
          Console.Write("The value must be IP Address, try again: ");
    
    Console.Write("Enter port : ");
    while (!int.TryParse(Console.ReadLine(), out port))
          Console.Write("The value must be of integer type, try again: ");
    
    string port = Console.ReadLine();
    Console.Write("Enter interval in MS : ");
    while (!int.TryParse(Console.ReadLine(), out TO))
          Console.Write("The value must be of integer type, try again: ");
    
    Console.Write("Enter number of threads to use : ");
    while (!int.TryParse(Console.ReadLine(), out threads))
          Console.Write("The value must be of integer type, try again: ");
    ipe1 = new IPEndPoint(ip, port);
