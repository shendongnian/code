    namespace My.Test
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			Console.WriteLine(Base.CreateInstance<Class1>().Func1());
    			Console.WriteLine(Base.CreateInstance<Class2>().Func1());
    		}
    	}    
     
    	public abstract class Base
    	{
    
    		public abstract string Func1();
    
    		public static T CreateInstance<T>() where T : Base, new()
    		{
    			return new T();
    		}
    	}
    
        public class Class1 : Base
        {
    	   public override string Func1() { return "class 1"; }
        }
    
        public class Class2 : Base
        {
    	   public override string Func1() { return "class 2"; }
        }
    }
