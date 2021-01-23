    static void Populate<T>(List<T> list, ...) where T: new()
    {
        ... 
        for (int i=0; i<rndNum; i++)
            list.Add(new T());
    }
