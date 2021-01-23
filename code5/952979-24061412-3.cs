    class Program
    {
        static void Main(string[] args)
        {
            bool[] array = { true, false, true, false, true };
            bool[] trueArray = { true, true, true, true };
            Console.WriteLine("Searching with a predicate:");
            Console.WriteLine(array.AreAll(x => x).ToString());
            Console.WriteLine(array.AreAll(x => !x).ToString());
            Console.WriteLine(trueArray.AreAll(x => x).ToString());
            Console.WriteLine(trueArray.AreAll(x => !x).ToString());
            Console.WriteLine("Searching without a predicate:");
            Console.WriteLine(array.AreAllTheSame().ToString());
            Console.WriteLine(array.AreAllTheSame().ToString());
            Console.WriteLine(trueArray.AreAllTheSame().ToString());
            Console.WriteLine(trueArray.AreAllTheSame().ToString());
            Console.ReadLine();
        }
    }
