    Console.WriteLine("Enter a number to find:");
    int mynumber = int.Parse(Console.ReadLine());
    for (int i = 0; i < x; i++)
    {
        for (int j = 0; j < y; j++)
        {
            if (MyArray[i, j].Equals(mynumber))
            {
                Console.WriteLine("The Number searched is {0}", mynumber);
            }
        }
    }
    Console.WriteLine("End of search ");
    Console.ReadLine();
