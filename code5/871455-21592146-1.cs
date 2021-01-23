            int count;
            bool attemptedSetCount = false;
            do
            {
                if (attemptedSetCount)
                {
                    Console.WriteLine("Please enter a valid integer");
                }
                Console.WriteLine("Enter how many values you are entering in");
                string countString = Console.ReadLine();
                attemptedSetCount = true;
            }
            while (!Int32.TryParse(countString, out count));
            int[] arr = new int[n];
            Console.WriteLine("Enter your values in");
            for (int i = 0; i < count; i++)
            {
                string valString = (Console.ReadLine());
                int val;
                if(!Int32.TryParse(valString, out val))
                {
                    Console.WriteLine("Please enter a valid integer");
                    i--;
                }
                else
                {
                    arr[i] = val;
                }
            }
