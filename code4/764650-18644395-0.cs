    public class A<T> where T:DataTable
       {
           
       }
    
        public class B :TypedTableBase<DataRow>
        {
        }
    
        class MyClass
        {
             A<B> asdf = new A<B>();
        }
