    public interface IFoo { void M(); }
    public abstract class Bar : IFoo
    {
        public virtual abstract void M();
        public void N() { }
    }
    public class Baz : Bar 
    {
        public override void M() { … } 
    }
    … 
    public void Method(Bar par)
    {
        par.M();
    }
    …
    
    Baz x = new Baz();
    Method(x);
