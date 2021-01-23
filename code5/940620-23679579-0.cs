    class Program
    {
        static void Main(string[] args)
        {
            int[] info = new int[] { 12, 0, 0, 48 };
            List<int> indxs = new List<int>();
            for (int i = 0; i < info.Length; i++)
                if (info[i] > 0)
                    indxs.Add(i);
            int[] building = indxs.ToArray();
            var newBuilding = info.Select((i, idx) => i == 0 ? -1 : idx)
                .Where(i => i != -1)
                .ToArray();
        }
    }
