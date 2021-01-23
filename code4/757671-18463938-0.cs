    void Main()
    {
    	var x = CreateClass<BaseC>("A");
    	x.Unwrap();
    }
    
    public T CreateClass<T>(string typeName) where T : BaseC 
    {
    	var type = Type.GetType(string.Format("MyNamespace.{0}",typeName));
    	return (T)Activator.CreateInstance(type);
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
