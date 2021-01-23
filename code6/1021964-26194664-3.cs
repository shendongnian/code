        static int ReadInt(string prompt)
        {
            for (;;)
            {
                Console.Write(prompt);
                int result;
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter an integral number.");
                }
            }
        }
