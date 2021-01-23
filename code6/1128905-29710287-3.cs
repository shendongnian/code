    private void RunScript(double z, int x, List<double> y, ref object A)
    {
        double[] results = new double[y.Count];
        System.Threading.Tasks.Parallel.For(0, y.Count, i =>
        {
          // read-only access of `y` is thread-safe:
          results[i] = Math.Pow((y[i] * x), z);
        });
        A = new List<double>(results);
    }
