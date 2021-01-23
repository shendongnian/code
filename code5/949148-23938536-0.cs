    public class A
    {
        public virtual void SomeMethod() { }
    }
    public class B : A
    {
        public sealed override void SomeMethod() { }
    }
    public class C : B
    {
        public override void SomeMethod() { }
    }
