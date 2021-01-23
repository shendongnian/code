    List<int> numbs = new List<int>();
    int num;
    for (int i = 0; i < 10; i++) 
    {
        num = Convert.ToInt32(Console.ReadLine());
        if(num % 2 == 0)
        {
           numbs.Add(num);
        }
    }
    foreach(int number in numbs)
    {
        Console.WriteLine("{0}", number);
    }
