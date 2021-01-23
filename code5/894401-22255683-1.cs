    using System;
    
    [AttributeUsage(AttributeTargets.All)]
    class FooAttribute : Attribute {}        
    
    [FooAttribute] // Full name
    class Test 
    {
        [Foo] // Abbreviated name
        public static void Main() {}
    }
