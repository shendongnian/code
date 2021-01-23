    static void Main(string[] args)
            {
                int length = 10;
                int[] myNumbers = new int[length];
    
                for (int i = 0; i < length; i++)
                {
                    Console.Write("Enter number:" );
                    myNumbers[i] = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                }
    
                Console.WriteLine("Your numbers: {0}", string.Join(",", myNumbers));
            }
