    public class BaseClass
    {
    }
    public class DerivedClass: BaseClass
    {
        public int Value;
    }
    ...
    BaseClass b = new BaseClass();
    DerivedClass d = (DerivedClass) b;
    int myValue = d.Value; // What would happen? BaseClass doesn't have a Value property!
