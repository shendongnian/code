    using System;
    
    [AttributeUsage(AttributeTargets.All)]
    class FooAttribute : Attribute
    {
    }
        
    
    [FooAttribute]
    class Test 
    {
        [Foo]
        public static void Main()
        {
        }
    }
