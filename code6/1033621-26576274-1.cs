    public bool IsSame(int[] a, int[] b)
    {
        return a.Length == b.Length &&
               a.Select((num, index) => num == b[index]).All(b => b);
    }
