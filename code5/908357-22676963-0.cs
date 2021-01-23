       class Program
        {
            static void Main(string[] args)
            {
                List<int> listOfInts = new List<int>() { 1, 4, 2, 56, 7 };
                listOfInts.Sort();
                foreach (int ii in listOfInts)
                {
                    Console.WriteLine("{0}", ii);
                }
                Console.WriteLine("Descending ...");
                listOfInts.Reverse();
                foreach (int ii in listOfInts)
                {
                    Console.WriteLine("{0}", ii);
                }
                Console.WriteLine("Hit any key to continue");
                Console.ReadKey();
            }
        }
