    int[] arr1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
    int[] arr2 = new int[] { 2, 4, 6 };
    // copy the content of arr1 and arr2 into a temporary Lists
    List<int> temp = new List<int>(arr1);
    List<int> temp2 = new List<int>(arr2);
    // remove all elements from list that exists in arr2
    foreach (int toRemove in arr2)
    {
        if(temp2.Contains(toRemove))
        {
            temp.Remove(toRemove);
        }
    }
    // it's done
    int[] result = temp.ToArray();
