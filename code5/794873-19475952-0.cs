    public void GenericMethod<T>() where T : struct
    {
       List<T> genericList = GetSomeData<T>();
       IList<double> doubleList = genericList.Select(val => Convert.ToDouble(val))
       										 .ToList();
    }
