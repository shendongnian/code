    public List<BaseClass> MyMethod()
    {
       retList.Add(new OtherDerivedClass());
    }
    List<DerivedClass> derivedList = MyMethod();
