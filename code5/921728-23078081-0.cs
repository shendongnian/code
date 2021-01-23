    namespace ConsoleApplication1
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			B b = new B(10);
    
    			// b.Number = 10; // Error here
    		}
    	}
    
    	public abstract class A
    	{
    		public A() { }
    
    		public A(int number)
    		{
    			Number = number;
    		}
    
    		private int _number;
    
    		public virtual int Number
    		{
    			get
    			{
    				return _number;
    			}
    			private set
    			{
    				_number = value;
    			}
    		}
    	}
    
    	public class B : A
    	{
    		public B(int number)
    			: base(number) { }
    
    		public override int Number
    		{
    			get
    			{
    				return base.Number;
    			}
    		}
    	}
    }
