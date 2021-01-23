    class Program
    {
        static Dictionary<int, Action> exercises = new Dictionary<int, Action>
        {
            // put the numbers with the exercise method here:
            {1, () => Exercise1()},
            {2, () => Exercise2()},
        }
        public static void Main(String[] args)
        {
            int opt;
            Console.WriteLine("program name");
            Console.WriteLine();
            // Print valid names - Alternatively get them from a list
            foreach (int i in exercises.Keys)
            {
                Console.WriteLine(string.Format("{0}. Exercise {0}", i));
            }
            Console.WriteLine();
            Console.WriteLine("Choose exercise number: ");
            opt = int.Parse(Console.ReadLine());
            // call like this:
            exercises[opt]();
        }
     }
