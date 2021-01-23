    public class ArrayComparer : IEqualityComparer<double[]>
        {
            public bool Equals(double[] x, double[] y)
            {
                return x.SequenceEqual(y);
            }
            public int GetHashCode(double[] obj)
            {
                return base.GetHashCode();
            }
        }
    var list = new double[] {1.4, 0.5, 3.6, 1.2};
    var list2 = new double[] { 0.3, 0.4, 3.1, 1.2 };
    var list3 = new double[] { 1.4, 0.5, 3.6, 1.2 };
          
    var lst = new List<double[]> {list, list2, list3};
    var newList = lst.Where(x => lst.Except(new List<double[]> {x}).Contains(x,new ArrayComparer()))
                             .Distinct(new ArrayComparer())
                             .ToList();
