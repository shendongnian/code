    IEnumerable<Type> GetTypes (IEnumerable<object> list)
    {
        foreach (object a in list)
        {
           yield return a.GetType();
        }
    }
