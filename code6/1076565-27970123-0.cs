    public static Tuple<int, int> FindTwoSum(IList<int> list, int sum)
    {
        Dictionary<int,int> indexOfValue= new Dictionary<int, int>();
        for (int i = 0; i < list.Count; i++)
        {
            indexOfValue[list[i]] = i;
        }
        for (int i = 0; i < list.Count; i++)
        {
            int value = list[i];
            int needed = sum - value;
            if (indexOfValue.ContainsKey(needed))
            {
               return new Tuple<int, int>(i, indexOfValue[needed]);
            }
        }
        return null;
    }
