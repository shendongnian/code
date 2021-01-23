    public class ScriptA
    {
        public delegate void MethodOneDelegate(int a, int b);
    
        public void MethodOne(int a, int b)
        {
            Console.WriteLine(a + b);
        }
    }
    
    public static class ScriptB
    {
        public static void StaticMethod(ScriptA.MethodOneDelegate function, int a, int b)
        {
            function(a, b);
        }
    }
    
    public static void Main()
    {
        ScriptA scriptA = new ScriptA();
        ScriptB.StaticMethod(scriptA.MethodOne, 1, 2);
    }
  
