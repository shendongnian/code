    class DoubleArrayStructuralEqualityComparer : EqualityComparer<double[]>
    {
        public override bool Equals(double[] x, double[] y)
        {
            return System.Collections.StructuralComparisons.StructuralEqualityComparer
                .Equals(x, y);
        }
        public override int GetHashCode(double[] obj)
        {
            return System.Collections.StructuralComparisons.StructuralEqualityComparer
                .GetHashCode(obj);
        }
    }
    ...
    var yourDict = new Dictionary<double[], string>(
        new DoubleArrayStructuralEqualityComparer());
    yourDict.Add(new[] { 3.14, 2.718, double.NaN, }, "da value");
    string read = yourDict[new[] { 3.14, 2.718, double.NaN, }];
