    namespace ConsoleApplication1
    {
        class Program
        {
            private const int MAX_NAME_LENGTH = 8;
            private const int MAX_NAMES = 5;
    
            private static string[] names = new string[MAX_NAMES];
            private static int currentIndex;
    
            static void Main(string[] args)
            {
                DrawBox();
    
                while (true)
                {
                    AskForAName();
                    StoreUserAnswer();
                    DrawBox();
                }
            }
    
            private static void AskForAName()
            {
                Console.WriteLine("Enter a name:");
            }
    
            private static void StoreUserAnswer()
            {
                string name = Console.ReadLine() ?? string.Empty;
                if (name.Length > MAX_NAME_LENGTH)
                {
                    name = name.Substring(0, MAX_NAME_LENGTH);
                }
    
                names[currentIndex] = name;
                currentIndex++;
                if (currentIndex > MAX_NAMES - 1)
                {
                    currentIndex = 0;
                }
            }
    
            private static void DrawBox()
            {
                Console.Clear();
                DrawDelimiter();
                DrawNames();
                DrawDelimiter();
            }
    
            private static void DrawDelimiter()
            {
                Console.WriteLine("*{0}*", new String('*', MAX_NAME_LENGTH));
            }
    
            private static void DrawNames()
            {
                for (int i = 0; i < MAX_NAMES; i++)
                {
                    DrawName(names[i] ?? string.Empty);
                }
            }
    
            private static void DrawName(string name)
            {
                Console.WriteLine("*{0}*", name.PadRight(MAX_NAME_LENGTH, ' '));
            }
        }
    }
