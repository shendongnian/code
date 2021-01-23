A custom IComparer&lt;int[]> is what you want here. Here is how I would write it. This is based on the assumption that a shorter array is less than a longer array. If that is not the case, the first if statement can be modified.
    public class ArrayComparer : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x.Length != y.Length)
                return x.Length - y.Length;
            for(int i = 0; i < x.Length; i++)
            {
                if (x[i] != y[i])
                    return x[i] - y[i];
            }
            return 0;
        }
    }
Using subtractions for the comparisons works well with how the return values of IComparer are specified.
