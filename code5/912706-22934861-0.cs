    int size = 2500000; //10000000 divided by 4
    int[] ar = new int[size];
    //random number init with numbers [0,size-1]
    System.Diagnostics.Stopwatch s = new Stopwatch();
    s.Start();
    for (int i = 0; i<4; i++)
    {
    var group = ar.GroupBy(i => i / num); 
    //the number of expected buckets is size / num.
    var l = group.ToArray();
    }
    s.Stop();
