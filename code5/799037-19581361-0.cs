    static void Main(string[] args)
    {
        int[] arr = new int[10];
        int count = 0;
        do
        {
            int a;
            if (int.TryParse(Console.ReadLine(), out a))
            {
                if ((a > 10) && (a < 100))
                {
                    if (!arr.Contains(a))
                    {
                        arr[count] = a;
                        count++;
                    }
                }
            }
        } while (count < 10);
        Console.ReadLine();
    }
