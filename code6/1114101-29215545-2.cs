    int take = 2;
    for (int i = 0; i < ints.Length; i += take)
    {
        if(i + take >= ints.Length)
            take = ints.Length - i;
        int[] subArray = new int[take];
        Array.Copy(ints, i, subArray, 0, take);
        averages.Add(subArray.Average());
    }
