    public class Program
    {
    	public static void Main()
    	{
    		A a = new A();
    		a.PrintThing();
    		
    		A newA = new B();
    		newA.PrintThing();
    	}
    
    	public class A
    	{
    		protected virtual bool Enabled
    		{
    			get
    			{
    				return true;
    			}
    		}
    
    		public void PrintThing()
    		{
    			Console.WriteLine(this.Enabled.ToString());
    		}
    	}
    
    	public class B : A
    	{
    		protected override bool Enabled
    		{
    			get
    			{
    				return false;
    			}
    		}
    	}
    }
