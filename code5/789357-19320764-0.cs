    int[] a = {1,2,3,4,5,2};
    var aLookupList = new HashSet<int>();
    foreach (int i in a)
    {
        bool isEven = i % 2 == 0;
        if (isEven)
        {
            aLookupList.Add(i);
            aLookupList.Add(i + 1);
        }
        else
        {
            aLookupList.Add(i);
        }
    }
    var result = aLookupList.ToArray();
