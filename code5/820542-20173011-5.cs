    void Main()
    {
        var arrayBlessings = new int[]{1, 2, 3, 4, 5, 6};
        var arrayGameBlessings = new int[5];
        var rnd = new Random();
        for (int i = 0; i < arrayGameBlessings.Length; i++)
        {
            int bless = rnd.Next(arrayBlessings.Length);
            arrayGameBlessings[i] = arrayBlessings[bless];
            arrayBlessings = arrayBlessings.Where(w => w != arrayBlessings[bless]).ToArray();
        }
        Console.WriteLine(arrayBlessings);
        Console.WriteLine(arrayGameBlessings);
    }
