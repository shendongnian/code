    List<int[]> a = new List<int[]>();
    
     int[] t1 = { 0, 4 };
     int[] t2 = { 0, 3, 2 };
     int[] t3 = { 0, 1, 3 };
     int[] t4 = { 0, 2, 4, 6, 1 };
     int[] t5 = { 0, 1, 1 };
     int[] t6 = { 0, 3, 4, 5 };
    
     a.Add(t1);
     a.Add(t2);
     a.Add(t3);
     a.Add(t4);
     a.Add(t5);
     a.Add(t6);
    
      a = a.OrderBy(arr=>arr.Length).ToList();
    
      foreach (int[] item in a)
      {
         foreach (int item2 in item)
         {
             Console.Write(" "+item2);
          }
        Console.WriteLine();
       }
