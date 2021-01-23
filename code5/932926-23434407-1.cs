    namespace My.Test
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			Console.WriteLine(Base<Class1>.Instance.Func1());
    			Console.WriteLine(Base<Class2>.Instance.Func1());
    		}
    	}
    
    	public abstract class Base
    	{
    		public abstract string Func1();
    	}
    
    	public sealed class Base<T> where T : Base, new()
    	{
    		public static T Instance
    		{
    			get { return new T(); }
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
