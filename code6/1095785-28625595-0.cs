    int[] arr = new int[50];                 // Original list
    List<int> maxList = new List<int>();     // Result list to hold max values
    int[] range = new int[10];               // Sub-list to check max value
    for (int i = 0; i < arr.Length - 9; i++)
    {
        Array.Copy(arr, i, range, 0, 10);    // Get sub-set
        maxList.Add(range.Max());            // Find max, add it to the result list
    }
