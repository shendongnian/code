    class MyClassComparer<T> : IEqualityComparer<MyClass>
    {
     public bool Equals(object otherInstance)
        {
            MyClass instance = otherInstance  as MyClass ;
            return (instance  != null) ? GetGuid.Equals(instance .GetGuid) : false;
        }
    
    public int GetHashCode()
        {
            return GetGuid.GetHashCode();
        }
    }
}
    
    listA.AddRange(listB); //Need to be List<ICommonInterface> Common Interface
    
    var distinctList = listA.Distinct(new MyClassComparer<T>());
