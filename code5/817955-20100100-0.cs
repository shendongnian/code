    public class Pointer<T>
    {
        public T Value {get;set;}
    }
---
    Pointer<SomeClass> A = new Pointer<SomeClass>(){ Value = new SomeClass()};
    Pointer<SomeClass> B = A;
    B.Value = null;    
    //A.Value is null
