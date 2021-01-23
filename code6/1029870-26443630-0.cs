    static void Main( string[] args )
    {
    	MethodB(() => Add(1, 2));
    
    	Console.ReadLine();
    }
    
    public static void Add(int i, int j)
    {
    	Console.WriteLine(i+j);
    }
    
    static public class DelegateWithDelegateParameter
    {
    	public static void MethodB(Action dAction)
    	{
    		dAction();
    	}
    }
