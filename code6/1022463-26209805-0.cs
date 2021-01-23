    public IList ReturnList(string key)
    {
        //var type = Data[key].GetType().Name;
        switch (key)
        {
            case "System.Boolean":
                return new List<bool>(); break;
            case "System.Int32":
                return new List<int>(); break;
            case "System.String":
                return new List<string>(); break;
        }
        return null;
    }
