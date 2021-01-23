    public struct Bound
    {
        public int Lower { get; set; }
        public int Upper { get; set; }
    }
    public static class Counting
    {
        public static IEnumerable<int[]> Indizes(this Bound[] bounds)
        {
            return Indizes(bounds, 0);
        }
        static IEnumerable<int[]> Indizes(this Bound[] bounds, int index)
        {
            if (index >= bounds.Length)
                yield return new int[] {};
            else
            {
                foreach(var comb in Indizes(bounds, index+1))
                {
                    for (var i = bounds[index].Lower; i < bounds[index].Upper; i++)
                    {
                        var newArr = new int[comb.Length + 1];
                        Array.Copy(comb, 0, newArr, 1, comb.Length);
                        newArr[0] = i;
                        yield return newArr;
                    }
                }
            }
        }
    }
