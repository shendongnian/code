    public void DoSomethingWithAllMyTypes(IAllMyTypes allMyTypes)
    {
        foreach (PropertyInfo propertyInfo in allMyTypes.GetType().GetProperties())
        {
            var x = propertyInfo.GetValue(allMyTypes) as IEnumerable
            if(x==null) throw new Exception("still wrong");
    
            DoSomething(x.Cast<MyDataObject>());
        }
    }  
