    public class Foo { }
    public class Bar : Foo { }   
    public class Baz : Foo { }
    public interface IX<out T, TBase> where T : TBase { }
    public abstract class X<T, TBase> : IX<T, TBase> where T : TBase { }
    public class Y : X<Bar, Foo> { }
    public class Z : X<Baz, Foo> { }
    public class W : X<Foo, Foo> { }
