    public bool IsSame(int[] a, int[] b)
    {
        return a.Length == b.Length &&
               Enumerable.Range(0, a.Length).All(i => a[i] == b[i]);
    }
