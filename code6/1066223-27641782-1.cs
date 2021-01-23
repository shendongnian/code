    public double? Solve(List<double> a, List<double?> x, double c)
    {
        int unknowns = 0;
        int unkonwnIndex;
        double sum = 0.0;
        // a.Count and x.Count assumed equal
        for (int i = 0; i < a.Count; i++) {
            if (x[i].HasValue) {
               sum += a[i] * x[i].Value;
            } else {
               unknowns++;
               unknownIndex = i;
            }
            if (unknowns != 1) {
               throw new ArgumentException("Exactly one unknown expected");
            }
            return (c - sum) / a[unknownIndex];
        }
    }
