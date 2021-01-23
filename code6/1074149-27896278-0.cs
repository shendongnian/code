    void Main()
    {
       int[] a1 = new int[5];
       int[] a2 = new int[5];
       for (int i = 0; i < 5; i++)
       {
           a1[i] = i;
           a2[i] = i + 5;
       }
       IEnumerable<int> a3;
       a3 = MergeFunction(a1, a2);
       Console.WriteLine(a3.ToArray()[0] + "");
       a1[0] = 10;
       Console.WriteLine(a3.ToArray()[0] + "");
       Console.ReadKey();
    }
    
    public IEnumerable<int> MergeFunction(int[] a1, int[] a2)
    {
    	return a1.Union(a2);
    }
