    List<int[]> arrayList = new List<int[]>();
    Random rnd = new Random();
    for (int i = 0; i < ints_array.Length; i++)
    {
         ints_array = ints_array.OrderBy(x => rnd.Next()).ToArray();
         var isDuplicate = arrayList.Any(x => x.SequenceEqual(ints_array));
         if (isDuplicate)
         {
               while (arrayList.Any(x => x.SequenceEqual(ints_array)))
               {
                   ints_array = ints_array.OrderBy(x => rnd.Next()).ToArray();
               }
          }
          arrayList.Add(ints_array);
    }
