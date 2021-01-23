    int arr[] = {1,1,1,12,12,16}
    for(int i = 0;i<2^arr.Length;i++)
    {
    int[] arrBin = BinaryFormat(i); // binary format i
    for(int j = 0;j<arrBin.Length;j++)
      if (arrBin[j] == 1)
         Console.Write("{0} ", arr[j]);
    Console.WriteLine();
    }
