    class DoubleArrayComparer: IEqualityComparer<double[]>
    {
        public bool Equals(double[] x, double[] y)
        {
            if (x == y)
                return true;
            if (x == null || y == null)
                return false;
            if (x.Length != y.Length)
                return false;
            for (int i = 0; i < x.Length; ++i)
                if (x[i] != y[i])
                    return false;
            return true;
        }
        public int GetHashCode(double[] data)
        {
            if (data == null)
                return 0;
            int result = 17;
            foreach (var value in data)
                result += result*23 + value.GetHashCode();
            return result;
        }
    }
    ...
    var yourDict = new Dictionary<double[], string>(new DoubleArrayComparer());
