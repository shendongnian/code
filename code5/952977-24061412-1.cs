    class Program
    {
        static void Main(string[] args)
        {
            bool[] array = { true, false, true, false, true };
            bool[] trueArray = { true, true, true, true };
            Console.WriteLine(array.AreAll(x => x).ToString()); // Check if all the elements in 'array' are true.
            Console.WriteLine(array.AreAll(x => !x).ToString()); // Check if all the elements in 'array' are false.
            Console.WriteLine(trueArray.AreAll(x => x).ToString()); // Check if all the elements in 'trueArray' are true.
            Console.WriteLine(trueArray.AreAll(x => !x).ToString()); // Check if all the elements in 'trueArray' are false.
            Console.ReadLine();
        }
    }
