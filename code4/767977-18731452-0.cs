    // Foo.DLL: 
    namespace Foo { public class Foo { } }
    
    // Bar.DLL: 
    namespace Bar { public class Foo { } }
    
    // Blah.DLL: 
    namespace Blah  
    {   
    using Foo;   
    using Bar;   
    class C { Foo foo; } 
    }
