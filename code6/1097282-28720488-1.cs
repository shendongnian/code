    int count = 15;
        
    List<int[]>[] list = new List<int[]>[count];
        
    for (int i = 0; i < count; i++)
    {
        list[i] = new List<int[]>(); //you have to initialize them
    }
    list[0].Add(new []{30, 22});
    list[0].Add(new []{11, 22});
    foreach (int[] numbers in list[0])
    {
       Console.WriteLine(string.Join(",",numbers)); //test
    }
