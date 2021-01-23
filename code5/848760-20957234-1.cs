    Console.WriteLine("Input a value: ");
    int x = int.Parse(Console.ReadLine());
    int[,] arr = new int[x, x];
    for (int i = 0; i < x; i++)
    {
        for (int j = 0; j < x; j++)
        {
            arr[i, j] = (i + 1) * (j + 1);
            Console.Write(arr[i, j] + " ");
        }
        Console.WriteLine();
    }
    Console.ReadLine();
