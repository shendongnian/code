    int[] arraySegment1 = new int[10];
    int[] arraySegment2 = new int[10];
    // populate arrays
    List<int[]> lists = new List<int[]>();
    lists.Add(arraySegment1);
    lists.Add(arraySegment2);
    lists[0][0] = 100000;
    System.Console.WriteLine(arraySegment1[0]); // then it will display 100000
