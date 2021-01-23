    int[] array = { 10, 5, 10, 2, 2, 3, 4, 5, 5, 7, 7, 8, 9, 7, 12, 12 };
    Dictionary<int, int> duplicateNumbers = new Dictionary<int, int>();
    int count=1;
    for (int i = 0; i < array.Length; i++)
    {
        count=1;
        if(!duplicateNumbers.ContainsKey(array[i]))
        {
            for (int j = i; j < array.Length-1; j++)
            {
                if (array[i] == array[j+1])
                {
                    count++;                            
                }
            }
            if (count > 1)
            {
                duplicateNumbers.Add(array[i], count);
            }
        }
    }
    foreach (var num in duplicateNumbers)
    {
        Console.WriteLine("Duplicate numbers, NUMBER-{0}, OCCURRENCE- {1}",num.Key,num.Value);
    }
