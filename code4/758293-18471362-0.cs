    Dictionary<string, string> kvs = new Dictionary<string, string>();
    
    if (array.Length % 2 == 0)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (i % 2 == 0)
            {
                kvs.Add(array[i], array[i+1]);
            }
        }
    }
    else
       // we have a problem with our array
