    public static void Main(string[] args)
    {
        int[] numbers = new int[] { 1, 6, 4, 11, 2, 5, 9, 3, 7, 10, 12, 8 };
        Console.WriteLine ("The scores are: ");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine (numbers [i]);
        }
        Console.WriteLine ("The scores in order are: ");
        SortArray (numbers);
        for (int i = 0; i < numbers.Length; i++)
        {
             Console.WriteLine (numbers [i]);
        }
        Console.ReadLine ();
    }
    public static int[] SortArray(int[] arrayIn)
    {
        Array.Sort (arrayIn);
        return arrayIn;
    }
