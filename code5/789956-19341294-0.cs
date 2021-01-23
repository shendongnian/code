    public IList RandomList()
    {
        var RandObj = new Random();
        var myint = RandObj.Next(1,3);
        switch(myint)
        {
            case 1: var StringList = new List<string>{ "Test" };
                return StringList;
            case 2: var IntList = new List<int>{ 1,2,3,4 };
                return IntList;
        }
    }
