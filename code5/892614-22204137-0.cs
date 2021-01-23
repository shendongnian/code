     static void ChangeArray(int[] array)
    {
        int index = Convert.ToInt32(Console.ReadLine());
        int newValue= Convert.ToInt32(Console.ReadLine());
        if(index <= array.Length && index >= 0)
        {
            array[index] = newValue;
        }
        Console.WriteLine("\n=============\n");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("{0}", array[i]);
        }
        Console.WriteLine("\n=============\n");
    }
