    public class ClosureClass1
    {
        public int i;
        public void AnonyousMethod1()
        {
            Console.WriteLine(i);
        }
    }
    static void Main(string[] args)
    {
        ClosureClass1 closure1 = new ClosureClass1();
        for (closure1.i = 0; closure1.i < 10; closure1.i++)
            new Thread(closure1.AnonyousMethod1).Start();
    }
