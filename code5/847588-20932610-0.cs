    public static class Extensions
    {
       public static void ExtensionMethod<T1, T2>(this A a)
       { 
           // ANywhere you would use the parameters use T1 and T2 instead.
       }
    }
    
    A a;
    a.ExtensionMethod<B, C>();
