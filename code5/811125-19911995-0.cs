    public void DoSomethingWithAllMyTypes(IAllMyTypes allMyTypes)
    {
        var method = this.GetType().GetMethod("DoSomething", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
        foreach (PropertyInfo propertyInfo in allMyTypes.GetType().GetProperties())
        {
            var x = propertyInfo.GetValue(allMyTypes, null);
            if(x==null) throw new Exception("still wrong");
    
            // obtain the type from the property - other techniques can be used here.
            var genericMethod = method.MakeGenericMethod(new[] {propertyInfo.PropertyType.GetGenericArguments()[0]})
            //execute the generic helper
            genericMethod.Invoke(this, new[]{x});
        }
    } 
    public void DoSomething<T>(IList<T> list) where T : MyDataObject {
      
    }
