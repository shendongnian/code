    int gi = 0, ii = 0;
    foreach(var g in list3)
    {
        foreach(item i in g)
        {
            Console.WriteLine("list3[{0}][{1}] = {2}", gi, ii, i); 
            ii++;
        }
        gi++;
    }
