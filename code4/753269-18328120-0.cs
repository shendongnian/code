    public static IEnumerable<IEnumerable<T>> GetPowerSet<T>(List<T> list)
    {
            return from m in Enumerable.Range(0, 1 << list.Count)
                   select
                       from i in Enumerable.Range(0, list.Count)
                       where (m & (1 << i)) != 0
                       select list[i];
    }
    private void button1_Click_2(object sender, EventArgs e)
    {
            List<int> temp = new List<int>() { 1,2,3};
            List<IEnumerable<int>> ab = GetPowerSet(temp).ToList();
            Console.Write(string.Join(Environment.NewLine,
                                     ab.Select(subset =>
                                     string.Join(",", subset.Select(clr => clr.ToString()).ToArray())).ToArray()));
    }
