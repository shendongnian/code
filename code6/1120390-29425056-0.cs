    public delegate void DoSomething();
    
    public class Program
    {
        static void Main()
        {
            List<DoSomething> actions = new List<DoSomething>();
            actions.Add(TestMethod);
            actions.Add(delegate {
               // Anonymous Method 1
            });
            actions.Add(delegate {
                // Anonymous Method 2
            });
        }
    
        static void TestMethod()
        {
            
        }
    }
