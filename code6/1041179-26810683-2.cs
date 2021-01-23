    public List<DerivedClass> MyMethod()
    {
       retList.Add(new DerivedClass());
    }
    IEnumerable<BaseClass> baseList = MyMethod();
