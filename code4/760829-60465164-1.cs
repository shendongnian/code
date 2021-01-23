    List<int> gcd = new List<int>();
    int n1, n2;
    
    bool com = false;
    
    Console.WriteLine("Enter first number: ");
    n1 = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter second number: ");
    n2 = int.Parse(Console.ReadLine());
    
    for(int i = 1; i <= n1; i++)
    {
        if(n1 % i == 0 && n2% i == 0)
        {
            gcd.Add(i);
        }
    
        if(i == n1)
        {
            com = true;
        }
    }
    
    if(com == true)
    {
        Console.WriteLine("GCD of {0} and {1} is {2}.", n1, n2, gcd[gcd.Count - 1]);
    }
    Console.ReadLine();
