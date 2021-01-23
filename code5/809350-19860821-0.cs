        public static void DoThis(int n)
        {
            var input = new char[n];
            for (var i = 0; i < input.Length; i++)
            {
                input[i] = Console.ReadKey().KeyChar;
            }
            
            Console.WriteLine(); // Linebreak
            Console.WriteLine(input);
            Console.ReadKey();
        }
