    private static void Main(string[] args)
    {
        string dialogResult = "";
        int size = 10;
        int[] array = Enumerable.Range(0, size).ToArray();
        Shuffle(array);
        for (int i = 0; i < size; i++)
        {
            int number = array[i];
            Console.WriteLine("Are you thinking of the number " + number.ToString() + "?");
            dialogResult = Console.ReadLine();
            if (dialogResult.ToUpper() == "Y")
            {
                break;
            }
        }
        if (dialogResult.ToUpper() == "Y")
        {
            Console.WriteLine("I guessed the number!");
        }
        else
        {
            Console.WriteLine("No numbers left!");
        }
        Console.ReadLine();
    }
