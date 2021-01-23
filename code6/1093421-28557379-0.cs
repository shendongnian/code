        static void Main(string[] args)
        {
            int top;
            Console.WriteLine();
            Console.Write("Type here: ");
            Console.WriteLine();
            for (int i = 0; i < 99; i++)
            {
                Console.WriteLine("hi" + Environment.NewLine);
            }
            top = Console.CursorTop;
            Console.MoveBufferArea(0, top - 199, Console.WindowWidth, 1, 0, top);
            Console.SetCursorPosition(11, Console.CursorTop);
            Console.ReadKey();
        }
