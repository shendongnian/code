    class A<T1, T2>
    {
    	public void Call<T>(T1 arg1, T2 arg2) where T : IDoSomething<T1>, IDoSomething<T2>, new()
    	{
    		T b = new T();
    		((IDoSomething<T1>)b).DoSomething(arg1); // determine which overload to use based on T1
    		((IDoSomething<T2>)b).DoSomething(arg2); // and T2
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
