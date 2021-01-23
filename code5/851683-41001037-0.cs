    static void A()
    {
        for (int i = 0; i < 5000; i++)
        {
            lock(thisLock) 
            {
                _concurrent.Add(new StateBag() { Name = "name" + i, Value = i.ToString() });
            }
        }
    }
