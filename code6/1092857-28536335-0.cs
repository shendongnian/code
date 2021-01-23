    public class GenericClass1<T1, T2>
        where T1: Class1
        where T2: Class2
    {
    }
    public class MyClass1 : GenericClass1<SubClass1, SubClass2>
    {
    }
    public class GenericClass2<T1, T2, T3>
        where T1: Class1
        where T2: Class2
	where T3:GenericClass1<T1, T2>
    {
    }
    public class MyClass2 : GenericClass2<SubClass1, SubClass2, MyClass1>
    {
    }
