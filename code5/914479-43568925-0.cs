    int large = 0;
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter interger :");
                int num = int.Parse(Console.ReadLine());
                if (num > large)
                {
                    large = num;
                }
               
            }
            Console.WriteLine(large);
