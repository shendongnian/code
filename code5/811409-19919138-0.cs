    class Program {
    	static void Main()
    	{
    		Parent foo = new Child();
    		foo.foo();
    	}
    }
	
	// Define other methods and classes here
	public class Parent
	{
		public virtual void foo() {
			Console.WriteLine("Parent::foo()");
		}
	}
	
	public class Derived : Parent
	{
		public override void foo() {
			Console.WriteLine("Derived::foo()");
		}
	}
	
	public class Child : Derived
	{
		public override void foo() {
			Console.WriteLine("Child::foo()");
		}
	}
