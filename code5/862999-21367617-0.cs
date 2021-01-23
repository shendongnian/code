        class DoubleArrayComparer : IEqualityComparer<double[]>
        {
            private DoubleArrayComparer() { }
            public static readonly DoubleArrayComparer Instance = new DoubleArrayComparer();
            public bool Equals(double[] x, double[] y)
            {
                return Enumerable.SequenceEqual(x, y);
            }
            public int GetHashCode(double[] obj)
            {
                //TODO: should implement better
                return 0;
            }
        }
        static void Main(string[] args)
        {
            List<double[]> li = new List<double[]>{
                new[]{1.4,0.5,3.6,1.2},
                new[]{0.3,0.4,3.1,1.2},
                new[]{1.4,0.5,3.6,1.2}
            };
            var query = li.GroupBy(x => x, DoubleArrayComparer.Instance)
                .Where(g => g.Count() == 1)
                .Select(y => y.Key)
                .ToList();
        }
