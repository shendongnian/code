    class A<T1, T2>
    {
    	public void Call<T>(T1 arg1, T2 arg2) where T : IDoSomething<T1>, IDoSomething<T2>, new()
    	{
    		T b = new T();
    		b.DoSomething(arg1);
    		b.DoSomething(arg2);
    	}
    }
    
    public interface IDoSomething<T>
    {
    	void DoSomething(T arg);
    }
    
    public class B : IDoSomething<int>, IDoSomething<float>
    {
    	void IDoSomething<int>.DoSomething(int arg)
    	{
    		Console.WriteLine("Got int {0}", arg);
    	}
    
    	void IDoSomething<float>.DoSomething(float arg)
    	{
    		Console.WriteLine("Got float {0}", arg);
    	}
    }
