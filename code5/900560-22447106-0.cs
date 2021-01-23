    public class Array_Sort
    {
    public static void Main()
    {
        int n = 0;
        const int SIZE = 20;
        int[] array = new int[SIZE];
        InputArray(array, ref n);
        if (IsSorted(array, n)) {
            Console.WriteLine("\n  The values in the array are in Ascending order");
        }
        else {
            Console.WriteLine("\n  The values in the array are NOT in Ascending order");
        }
    }
    public static void InputArray(int[] array, ref int SIZE)
    {
        int i = 0;
        
        Console.Write("\n Enter the number of elements  : ");
        SIZE = Convert.ToInt32(Console.ReadLine());
        for (i = 0; i < SIZE; ++i)
        {
            Console.WriteLine("\n Enter the element- {0}  : ", i+1);
            array[i] = Convert.ToInt32(Console.ReadLine());
        }
    }
    public static bool IsSorted(int[] array, int n)
    {
        int i;
        int count =1;
        for (i = 0; i < n; i++) { 
            if(i>=1){
                if (array[i] > array[i - 1]) {
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
