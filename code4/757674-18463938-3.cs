    void Main()
    {
    	var x = CreateClass("A");
    	x.Unwrap();
    }
    
    public BaseC CreateClass(string typeName)
    {
    	var type = Type.GetType(string.Format("MyNamespace.{0}",typeName);
    	return (BaseC)Activator.CreateInstance(type);
    }
    
    
    public class A : BaseC
    {
    	public override void Unwrap()
    	{
    		Console.WriteLine("A");
    	}
    }
    
    public class B : BaseC
    {
    	public override void Unwrap()
    	{
    		Console.WriteLine("B");
    	}
    }
    
    public class BaseC
    {
    	public virtual void Unwrap()
    	{
    		Console.WriteLine("BaseC");
    	}
    }
    //// Here is the approach with an Interface (note that overrides and virtual declaration needed. 
    
   
    void Main()
    	{
    		var x = CreateClass<IBase>("MyNamespace","A");
    		x.Unwrap();
    	}
    	
    	public T CreateClass<T>(string classNamespace, string typeName) where T : class
    	{
    		var type = Type.GetType(string.Format("{0}.{1}",classNamespace, typeName));
    		return (T)Activator.CreateInstance(type);
    	}
    	
    	
    	public class A : IBase
    	{
    		public void Unwrap()
    		{
    			Console.WriteLine("A");
    		}
    	}
    	
    	public class B : IBase
    	{
    		public void Unwrap()
    		{
    			Console.WriteLine("B");
    		}
    	}
    	
    	public interface IBase
    	{
    		void Unwrap();
    	}
