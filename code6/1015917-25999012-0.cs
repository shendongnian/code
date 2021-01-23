     namespace Patterns
    {
        class Program
        {
            static void Main(string[] args)
            {
                for (int i = 1; i <= 4; i++)//'rows'
                {
                    for (int j = 0; j < i -1; j++) {
                        Console.Write(" ");
                    }
                    for (int h = 1; h <= 9 - (i*2)+1; h++)
                    {
                        Console.Write("#");
                    }
    
                    Console.WriteLine("\n" );
    
                }
            }
        }
    }
