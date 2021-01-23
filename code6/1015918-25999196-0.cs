    for (int i = 1; i <= 4; i++)//'rows'
            {
                for (int h = 1; h <= 9 - (i*2)+1; h++)
                {
                    Console.Write("#");
                }
                Console.WriteLine("\n" );
                for (int y = i; y > 0; y--)
                {
                    Console.Write(" ");    
                }
            }
