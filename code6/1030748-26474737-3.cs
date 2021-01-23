    static IEnumerable<T> TestMethod<T>(T [] test,int option)
    {
        switch (option)
        {
            case 1://Return array of strings
            return test;
    
            case 2:
            return new List<T>(test);
    
            case 3:
            return new Stack<T>(test);
        }
    }
