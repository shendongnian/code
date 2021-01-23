    public void Setup()
    {
        Class1List list1 = new Class1List();
    
        var query = from x in BaseClassList
                    where x.Type = MyType.Class1
                    select x as Class1;
    
        list1.AddRange(query);
    }
