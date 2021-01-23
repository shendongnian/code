    static IEnumerable<string> TestMethod(string [] test,int option)
    {
        switch (option)
        {
            case 1://Return array of strings
            return test;
    
            case 2:
            return new List<string>(test);
    
            case 3:
            return new Stack<string>(test);
        }
    }
