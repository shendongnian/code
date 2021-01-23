    int[] arr = new int[200];                // Original list of lines
    List<int> maxList = new List<int>();     // Result list to hold max values
    int[] range = new int[10];               // Sub-list of lines to check max value
    for (int i = 0; i < arr.Length - 9; i++)
    {
        Array.Copy(arr, i, range, 0, 10);    // Get sub-set of lines
        maxList.Add(range.Max());            // Find max, add it to the result list
    }
