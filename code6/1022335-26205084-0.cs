    class ArrayComparer : IEqualityComparer<int[]>
    {
        public bool Equals(int[] x, int[] y)
        {
            return x.SequenceEqual(y);
        }
        public int GetHashCode(int[] obj)
        {
            int h = 0;
            foreach (int item in obj)
            {
                h = (h << 5) + 3 + h ^ item.GetHashCode();
            }
            return h;
        }
    }
    Test.Contains(new int[] { 20, 20 }, new ArrayComparer())
