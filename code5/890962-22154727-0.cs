    static void Main(string[] args)
        {
            int[] A = { -2, 5, -1, 9, -6, 23, 67, 1, -8, 7, -3, 90 };
            int index = FirstPosOddNum(A);
            if (index >= 0)
            {
                Console.WriteLine("The first Positive value is: {0}, In Index {1}",
                    A[index], index);
            }
            else
            {
                Console.WriteLine("No positive odd value available.");
            }
            Console.ReadLine();
        }
        static int FirstPosOddNum(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 1)
                    return i;
            }
            return -1;
        }
