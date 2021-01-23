    public double Solve(IList<double> a, IList<double?> x, double c)
    {
        int unknowns = 0;
        int unkonwnIndex = 0; // Initialization required because the compiler is not smart
                              // enough to infer that unknownIndex will be initialized when
                              // our code reaches the return statement.
        double sum = 0.0;
        if (a.Count != x.Count) {
           throw new ArgumentException("a[] and x[] must have same length");
        }
        for (int i = 0; i < a.Count; i++) {
            if (x[i].HasValue) {
               sum += a[i] * x[i].Value;
            } else {
               unknowns++;
               unknownIndex = i;
            }
        }
        if (unknowns != 1) {
           throw new ArgumentException("Exactly one unknown expected");
        }
        return (c - sum) / a[unknownIndex];
    }
