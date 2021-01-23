            int[] matrix = new int[5];
            Console.WriteLine("Enter a 5 digit number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = number % 10;
                number = number / 10;
            }
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(matrix[i]);
            }
            Console.ReadLine();
