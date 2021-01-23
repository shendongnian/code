    public class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new [] {1, 2, 3};
            IEnumerator enumerator = arr.GetEnumerator();
            enumerator.MoveNext();
            Console.WriteLine(enumerator.Current);
            DoRest(enumerator);
        }
        static void DoRest(IEnumerator enumerator)
        {
            while (enumerator.MoveNext())
                Console.WriteLine(enumerator.Current);
        }
    }
