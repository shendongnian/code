    public class Class1
        {
        }
    
        public class SubClass1 : Class1
        {
        }
    
        public class Class2
        {
        }
    
        public class SubClass2 : Class2
        {
        }
    
        public class GenericClass1<T1, T2>
            where T1 : Class1
            where T2 : Class2
        {
        }
    
        public class MyClass1 : GenericClass1<SubClass1, SubClass2>
        {
        }
    
       
        public class GenericClass2<U>
            where U : GenericClass1<SubClass1, SubClass2>
        {
        }
    
        public class MyClass2 : GenericClass2<MyClass1>
        {
        }
