    int sum = 0;
    foreach (var item in list)
    {
        sum += item.a;
        if(item is Inh)
        {
           Inh inh = (Inh)item;
           Console.WriteLine(inh.b);
        }
    }
