    static void Main(string[] args)
    {
        string fileNumbers = File.ReadAllText("sort(5).txt");
        string[] intNumbers = fileNumbers.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        int[] numbers = new int[intNumbers.Length];
        int len = numbers.Length;
        for (int n = 0; n < intNumbers.Length; n++)
        {
            numbers[n] = int.Parse(intNumbers[n]);
        }
        Console.WriteLine("MergeSort: ");
        MergeSort_Recursive(numbers, 0, len - 1);
        for (int i = 0; i < numbers.Length; i++)
            Console.WriteLine(numbers[i]);
        //Console.Read(); //Not sure what this is for....
    }
