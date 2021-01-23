    public class Combination<T>
    {
        static T[] res;
        private static void Combine(int ix, List<List<T>> data, ref List<T[]> allCombos)
        {
            foreach (T v in data[ix])
            {
                res[ix] = v;
                if (ix >= data.Count - 1)
                {
                    allCombos.Add(res);
                }
                else
                {
                    Combine(res, ix + 1, data, ref allCombos);
                }
            }
        }
    public static List<T[]> Combine(List<List<T>> data)
    {
        List<T[]> allCombos = new List<T[]>();
        res = new  T[data.Count];
        Combine(0, data, ref allCombos);
        return allCombos;
    }
}
