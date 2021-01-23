        static void Main(string[] args)
        {
            Random r = new Random();
            int[] x = new int[20];
            for (int i = 0; i < 20; i++)
            {
                x[i] = r.Next(100);
                Console.Write(x[i] + " ");
            }
            Console.WriteLine("New array is : ");
            for (int k = 0; k < 20; k++)
            {
                for (int n = k + 1; n < 20; n++)
                {
                    if (x[n] == x[k])
                    {
                        int newNumber;
                        //Keeps generating a number which doesnt exists 
                        //in the array already
                        do
                        {
                            newNumber = r.Next();
                        } while (contains(x, newNumber));
                        //Done generating a new number.
                        Console.Write("New number is: ");
                        x[k] = newNumber;
                    }
                }
                Console.WriteLine(x[k]);
            }
        }
        /// <summary>
        /// Returns true if the given array contains the given number
        /// </summary>
        /// <param name="array">The array to check</param>
        /// <param name="number">The number to check</param>
        /// <returns>bool True if number exists in array</returns>
        static bool contains(int[] array, int number)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                {
                    return true; //Returns true if number already exists
                }
            }
            return false;
        }
