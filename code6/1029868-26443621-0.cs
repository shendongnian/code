    public void delegate adddelegate(int, int);
    
    static void Main( string[] args )
    { 
      adddelegate adddel = new adddelegate(Add);
      
      DelegateWithDelegateParameter.MethodB(1, 2, adddel);
    
      Console.ReadLine();
    } 
    public static void Add(int i, int j)
    {
        Console.WriteLine(i+j);
    }
    static public class DelegateWithDelegateParameter
        {
            public static void MethodB(int param1, int param2, adddelegate dAction)
            {
                dAction(param1, param2);
            }
        }
