    public static class Extension
    {
        public static void AddWeightedNo(this List<int> nos, int no, int weight)
        {
            for (int i = 0; i < weight; i++)
            {
                nos.Add(no);
            }
        }
    
        public static void RemoveWeightedNo(this List<int> nos, int no)
        {
            nos.RemoveAll(o => o == no);
        }
    }
