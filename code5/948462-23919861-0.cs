    int[] arr1 = { 1, 1, 1, 1 };
    int[] arr2 = { 2, 2, 3, 2, 2 };
    int[] arr = new int[5];
    Array.Copy(arr1, 0, arr, 0, 2);
    Array.Copy(arr2, 1, arr, 2, 3);
    Console.WriteLine(string.Join(" ", arr));
