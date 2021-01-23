I think yield might solve your problem.  This will allow you to control enumeration from the calling code so you may escape early when you need to.
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var dataTable in GetData())
            {
                Console.WriteLine("Got more data.");
                
                Console.WriteLine("Continue getting more data?");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.KeyChar != 'y')
                { 
                    // Stop enumerating.
                    break; 
                }
            }
            Console.ReadKey(true);
        }
        static IEnumerable<DataTable> GetData()
        {
            while (true)
            {
                yield return new DataTable();
            }
        }
    }
Also notice the return type IEnumerable&lt;out T&gt;.
