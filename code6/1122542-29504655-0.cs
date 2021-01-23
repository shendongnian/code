public class Foo {
    //...
}
public class Bar {
    protected Foo m_foo;
    
    //C# passes by reference for objects, so any changes to Foo would be reflected
    //in m_foo
    public Bar(Foo foo){
        m_foo = foo;
    }
}
public main(){
    Foo foo = new Foo();
    Bar bar = new Bar(foo);
    Bar bar2 = new Bar(foo);
    foo = null;
    //Both bar and bar2 have the same reference to foo.
    //Any changes to foo from bar will be visible to bar2
    //Even though foo is set to null, the object is not actually removed
    //since both bar and bar2 have a reference to it.
}
