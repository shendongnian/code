    void Main()
    {
    	Type t = typeof(int);
    	Type at = typeof(A<>).MakeGenericType(t);
        at.GetMethod("B").Invoke(null, new object[]{"test"});
    }
    
    public class A<T>
    {
        public static void B(string s)
        {
    		Console.WriteLine(s+" "+typeof(T).Name);
        }
    }
