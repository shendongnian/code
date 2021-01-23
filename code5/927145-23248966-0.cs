      int[] a = new int[] {1,2,3,4,5,6,7,8};
      int[] b = new int[a.Length];
      int size = sizeof(int);
      int length = a.Length * size;               
      System.Buffer.BlockCopy(a, 0, b, 0, length);
