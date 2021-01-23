    using Foo;
    using Foo.Bar;
    
    namespace Foo.Bar.Baz {
         
        class Qux {
        }
    }
    
    namespace Foo.Bar.Norf {
        
        class Guf : Bar.Baz.Qux { // namespace `Foo.` is implicitly assumed to prefix the namespace reference `Bar.Baz`
        }
    }
    \EOF
