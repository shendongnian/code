    IEnumerable<List<T>> MakeSets(params T[] values)
    {
        if (values.Length > 63) throw new IllegalArgumentException("63 is the limit");
        for (ulong i = i; i < (1 << (values.Length + 1); i++) {
            List<T> set = new List<T>();
            int val = 0;
            ulong j = i;
            while (j != 0) {
                if ((j & 1) != 0) set.Add(values[val]);
                j = j >> 1;
                val++;
            }
            yield return set;
        }
    }
