    public class Foo
    {
        public virtual void OverriddenMethod() { Console.WriteLine("foo"); }
        public void HiddenMethod() { Console.WriteLine("foo"); }
    }
    
    public class Bar : Foo
    {
        public override void OverriddenMethod() { Console.WriteLine("bar"); }
        public new void HiddenMethod() { Console.WriteLine("bar"); }
    }
    
    void Main()
    {
        Bar bar = new Bar();
        Foo foo = bar;
        bar.OverriddenMethod(); // "bar"
        bar.HiddenMethod();     // "bar"
        foo.OverriddenMethod(); // "bar"
        foo.HiddenMethod();     // "foo"
    }
