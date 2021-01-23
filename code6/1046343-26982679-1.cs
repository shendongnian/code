      static void Main()
      {
            var map = new Dictionary<object, IList<int>>();
            map.Add("item_1", new int[] { 2, 2, 4 });
            map.Add("item_2", new int[] { 1, 3, 4 });
            map.Add("item_3", new int[] { 2, 3, 4 });
            map.Add("item_4", new int[] { 1, 2});
            
            var list = new List<KeyValuePair<object, IList<int>>>(map);
            list.Sort(CompareSequences);
            foreach(var item in list)
            {
                Console.WriteLine("{0} ({1})", item.Key, string.Join<int>("," , item.Value));
            }
      }
    
        static int CompareSequences(KeyValuePair<object, IList<int>> left, 
            KeyValuePair<object, IList<int>> right)
        {
             int count = Math.Min(left.Value.Count, right.Value.Count);
            for (int i = 0; i < count; ++i)
            {
                if (left.Value[i] < right.Value[i])
                {
                    return -1;
                }
                 
                if (left.Value[i] > right.Value[i])
                {
                    return 1;
                }
            }
            if (right.Value.Count > count)
            {
                return -1;
            }
            if (left.Value.Count  > count)
            {
                return 1;
            }
            return 0;
        }
