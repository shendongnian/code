       public class MyTypedClass1 : DynamicObject
       {
           public string SomeProperty { get; set; }
       }
       public class MyGeneric<T> : DynamicObject
       {
           // just some property to get the idea
           public T Value { get; set; }
       } 
       public static class MyGenericExtensions
       {
           public static MyGeneric<dynamic> ConveretGeneric(this MyGeneric<MyTypedClass1> argument)
           {
               return new MyGeneric<dynamic>()
               {
                   // here you need to assign all needed properties
                   Value = argument.Value
               };
           }
       }
