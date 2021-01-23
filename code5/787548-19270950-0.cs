    void Main()
    {
        var t = new Test();
        t.Execute();
    }
    
    public class Test
    {
        public void Execute()
        {
            Debug.WriteLine("Execute");
        }
    }
