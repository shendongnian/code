    int n;
    Console.WriteLine("Please enter a positive integer for the array size"); // asking the user for the int n
    n = Int32.Parse(Console.ReadLine());
    int[] array = new int[n]; // declaring the array
    int[] newarray = new int[n];
    Random rand = new Random();
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = i + 1;
        newarray[i] = i + 1;
    }
    for (int y = 0; y < newarray.Length; y++)
    {
        int r = rand.Next(n);
        int tmp = newarray[y];
        newarray[y] = newarray[r];
        newarray[r] = tmp;
    }
    for (int x=0;x<newarray.Length;x++)
    {
        Console.Write(" {0}", newarray[x]);
    }
    Console.ReadLine();
