    public static class Extensions
    {
       public static void ExtensionMethod(this A a, Type c1, Type c2)
       { 
       }
    }
    A a;
    a.ExtensionMethod(typeof(B), typeof(C));
