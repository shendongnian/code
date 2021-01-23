            static void Main(string[] args)
        {
            String input;
            Int32 n_In, i = 1;
            List<Int32> user_Inputs = new List<int>();
            while ((input = Console.ReadLine()).Length > 0)
                if (int.TryParse(input, out n_In)) user_Inputs.Add(n_In);
            Console.WriteLine("Numbers entered: ");
            if (user_Inputs.Count == 0) return;
            foreach (Int32 n in user_Inputs)
                Console.WriteLine("Number" + i++ + ": " + n);
            Console.ReadKey();
        }
