    public static Tuple<int, int> FindTwoSum(IList<int> list, int sum)  {
            int needed;
            Dictionary<int, int> indexOfValue = new Dictionary<int, int>();
    
            for (int i = 0; i < list.Count; i++){
                needed = sum - list[i];
                if (indexOfValue.ContainsKey(needed)) {
                    return new Tuple<int, int>(i, indexOfValue[needed]);
                }
                    
                indexOfValue[list[i]] = i;
            }
            
            return null;
    }
