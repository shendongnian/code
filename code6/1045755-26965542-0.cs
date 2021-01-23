    int[] num = new int[1000];
    Random rnd = new Random();
    for (int i = 0; i < 1000; i++)
    {        
        num[i] = rnd.Next(1000);
        Console.WriteLine(num[i]);
        //Console.WriteLine(num[i] = rnd.Next(1000));
    }          
    Console.WriteLine("Press Enter to sort the array");
    Console.ReadLine();
    Array.Sort(num);
    for (int i = 0; i < 1000; i++)
    {        
        Console.WriteLine(num[i]);
    }          
    Console.ReadLine();
