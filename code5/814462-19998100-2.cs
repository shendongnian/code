    static double ParallelPi()
    {
        double sum = 0.0;
        double step = 1.0 / (double)NUM_STEPS;
        object obj = new object();
        Parallel.For(0, NUM_STEPS,
        () => 0.0,
        (i, state, partial) =>
        {
            double x = (i + 0.5) * step;
            return partial + 4.0 / (1.0 + x * x);
        },
        partial => { lock (obj) sum += partial; });
        return step * sum;
    }
