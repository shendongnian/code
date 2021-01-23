    public class Base
	{
		public virtual void VirtualMethod() { }
		public void NewMethod() { }
	}
	public class Derived : Base
	{
		public override void  VirtualMethod() { }
		public new void NewMethod() { }
	}
    ...
    Base derived = new Derived();
    derived.VirtualMethod(); // Derived.VirtualMethod()
    derived.NewMethod(); // Base.NewMethod()
    ((Derived)derived).NewMethod(); // Derived.NewMethod()
