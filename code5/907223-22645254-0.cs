    public class Taxi
    {
        public bool isInitialized;
        public Taxi()
        {
            isInitialized = true;
        }
    }
    class TestTaxi
    {
        static void Main()
        {
            Taxi t1 = new Taxi();
            Taxi t2 = new Taxi();
            t2.isInitialized = false;
            Console.WriteLine(t1.isInitialized);
            Console.WriteLine(t2.isInitialized);
            Console.ReadKey();
        }
    }
