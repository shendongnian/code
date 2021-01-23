    int count = 15;
        
    List<int>[] list = new List<int>[count];
        
    for (int i = 0; i < count; i++)
    {
        list[i] = new List<int>(); //you have to initialize them
    }
    list[0].Add(30);
    list[0].Add(32);
    foreach (int number in list[0])
    {
       Console.WriteLine(number); //test
    }
