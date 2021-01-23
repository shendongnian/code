       class Foo
       {
           public void Baz() { Assert("Foo.Baz"); }
       }
    
       class ChildOfFoo : Foo
       {
           public new void Baz() { Assert("ChildOfFoo.Baz"); }
       }
       Foo foo = new ChildOfFoo();
       foo.Baz(); // Foo.Baz
