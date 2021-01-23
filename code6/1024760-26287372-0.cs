    [TestMethod]
    public void test()
    {
        var data = new string[]{
            "1 1 2 0.39785 0.39785 0.2043 36",
            "1 1 3 0.409604 0.409604 0.180792 24",
            "1 1 4 0.407281 0.407281 0.185438 24",
            "1 1 5 0.404958 0.404958 0.190084 24",
            "1 1 6 0.403399 0.403399 0.193203 24"
        };
        var dic = new FloatLookup(data);
        var test1 = dic.GetValues(211).ToArray();
        CollectionAssert.AreEquivalent(new float[] { 0.39785F, 0.39785F, 0.2043F }, test1);
        var test2 = dic.GetValues(121).ToArray();
        CollectionAssert.AreEquivalent(new float[] { 0.39785F, 0.2043F, 0.39785F  }, test2);
        var test3 = dic.GetValues(611).ToArray();
        CollectionAssert.AreEquivalent(new float[] { 0.193203F, 0.403399F, 0.403399F }, test3);
    }
    class FloatLookup
    {
        Dictionary<int, KeyValuePair<int, float>[]> dic;
        public FloatLookup(string[] data)
        {
            dic = data.Select(GetKeyValuePair).
                ToDictionary(o => o.Key, o => o.Value);
        }
        public IEnumerable<float> GetValues(int num)
        {
            return GetValues(GetInts(num));
        }
        public IEnumerable<float> GetValues(IEnumerable<int> ints)
        {
            var key = GetKey(ints);
            KeyValuePair<int, float>[] kvps = null;
            if (!dic.TryGetValue(key, out kvps))
                yield break;
            foreach (var i in ints)
                yield return kvps.First(o => o.Key == i).Value;
        }
        static KeyValuePair<int, KeyValuePair<int, float>[]> GetKeyValuePair(string line)
        {
            var items = line.Split(' ');
            var ints = new string[] { items[0], items[1], items[2] }.
                Select(o => int.Parse(o)).ToArray();
            var floats = new string[] { items[3], items[4], items[5] }.
                Select(o => float.Parse(o)).ToArray();
            var kvps = Enumerable.Range(0, 3).Select(o =>
                new KeyValuePair<int, float>(ints[o], floats[o])).Distinct().ToArray();
            var key = GetKey(ints);
            return new KeyValuePair<int, KeyValuePair<int, float>[]>(key, kvps);
        }
        static int[] GetInts(int num)
        {
            return num.ToString().ToCharArray().Select(o => 
                int.Parse(o.ToString())).ToArray();
        }
        static int GetKey(IEnumerable<int> ints)
        {
            var ret = 0;
            var ary = ints.ToArray();
            Array.Sort(ary);
            var c = 1;
            for (int i = ary.GetUpperBound(0); i > -1; i--)
            {
                ret += ary[i] * c;
                c *= 10;
            }
            return ret;
        }
