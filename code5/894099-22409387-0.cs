    public IEnumerable<int> LoopUsingGetter()
    {
        int dummy = 314;
       
        for (int i = 0; i < NumRepet; i++)
        {
            dummy++;
            yield return dummy;
        }
    }
    [ThreadStatic]
    private static int dummy = 314;
    public static int Dummy
    {
        get
        {
            if (dummy != 314) // or whatever your condition
            {
                return dummy;
            }
 
            Parallel.ForEach (LoopUsingGetter(), (i)
            {
                //DoWork(), not ideal for given example, but due to the generic context this may help
                dummy += i;
            });
        }
        return dummy;
    }
