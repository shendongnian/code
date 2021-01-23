    public class Array_Sort
    {
        public static int n = 0;
        public static int SIZE = 20;
        public static int[] array = new int[SIZE];
        public static void Main()
        {
            InputArray();
            if (IsSorted())
            {
                Console.WriteLine("\n  The values in the array are in Ascending order");
            }
            else
            {
                Console.WriteLine("\n  The values in the array are NOT in Ascending order");
            }
        }
        public static void InputArray()
        {
            int i = 0;
            Console.Write("\n Enter the number of elements  : ");
            SIZE = Convert.ToInt32(Console.ReadLine());
            if (SIZE > 20)
            {
                Console.WriteLine("\n Invalid Selection, try again \n\n ");
                InputArray();
            }
            else
            {
                for (i = 0; i < SIZE; ++i)
                {
                    Console.WriteLine("\n Enter the element- {0}  : ", i + 1);
                    array[i] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        public static bool IsSorted()
        {
            int i;
            int count = 1;
            for (i = 0; i < n; i++)
            {
                if (i >= 1)
                {
                    if (array[i] > array[i - 1])
                    {
                        count++;
                    }
                }
            }
            if (count == n)
                return true;
            else
                return false;
        }
    }
