    class Program
    {
        static int m_nextNumber = 0;
        static void Main(string[] args)
        {
            var t1 = Version1();
            m_nextNumber = 0;
            var t2 = Version2();
            Task.WaitAll(t1, t2);
            Console.ReadKey();
        }
        static async Task Version1()
        {
            List<int> hello = new List<int>();
            await Say(hello);
            await Say(hello);
            PrintHello(hello);
        }
        static async Task Version2()
        {
            List<int> hello = new List<int>();
            await Task.WhenAll(Enumerable.Range(0, 2).Select(async x => await Say(hello)));
            PrintHello(hello);
        }
        static void PrintHello(List<int> hello)
        {
            foreach (var i in hello)
                Console.WriteLine(i);
        }
        static int GotANumber()
        {
            return m_nextNumber++;
        }
        static async Task Say(List<int> hello)
        {
            var rep = GotANumber();
            hello.Add(rep);
        }
    }
