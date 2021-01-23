            [Test]
            public void TestFunctionEval()
            {
                int numObj = 2;
                int m = 100000;
    
                Func<double[], double[]> fun1 = (x) =>
                {
                    double[] z = new double[numObj];
                    z[0] = x[0];
                    double g = 1.0;
                    for (int i = 1; i < x.Length; i++)
                        g = g + 9.0 * x[i] / (m - 1);
                    double h = 1.0 - Math.Sqrt(z[0] / g);
                    z[1] = g * h;
                    return z;
                };
    
                Func<ILInArray<double>, ILRetArray<double>> fun2 = (xIn) =>
                {
                    using (ILScope.Enter(xIn))
                    {
                        ILArray<double> x = xIn;
                        ILArray<double> z = zeros(numObj);
                        z[0] = x[0];
                        ILArray<double> g = 1.0 + 9.0*sum(x[r(1, end)])/(m - 1);
                        ILArray<double> h = 1.0 - sqrt(z[0]/g);
                        z[1] = g*h;
                        return z;
                    }
                };
    
                Func<Vector<double>, Vector<double>> fun3 = (x) =>
                {
                    DenseVector z = DenseVector.Create(numObj, (i) => 0);
                    z[0] = x[0];
                    double g = 1.0 + 9.0*(x.SubVector(1, m - 1) / (m - 1)).Sum();
                    double h = 1.0 - Math.Sqrt(z[0] / g);
                    z[1] = g * h;
                    return z;
                };
    
                int n = 1000;
                ILArray<double> xs = rand(n, m);
                IList<double[]> xRaw = new List<double[]>();
                for (int i = 0; i < n; i++)
                {
                    double[] row = xs[i, full].ToArray();
                    xRaw.Add(row);
                }
                DenseMatrix xDen = DenseMatrix.OfRows(n, m, xRaw);
    
                int numTest = 10;
    
                for (int k = 0; k < numTest; k++)
                {
                    log.InfoFormat("Round {0}.", k);
                    Stopwatch watch = new Stopwatch();
                    watch.Reset();
                    watch.Start();
                    for (int i = 0; i < n; i++)
                    {
                        ILArray<double> ret = fun1(xRaw[i]);
                    }
                    watch.Stop();
                    log.InfoFormat("System array took {0} seconds.", watch.Elapsed.TotalSeconds);
                    watch.Reset();
                    watch.Start();
                    for (int i = 0; i < n; i++)
                    {
    //                    ILArray<double> ret = fun2(xs[i, full]);
                        ILArray<double> ret = fun2(xRaw[i]);
                    }
                    watch.Stop();
                    log.InfoFormat("ILNumerics took {0} seconds.", watch.Elapsed.TotalSeconds);
                    watch.Reset();
                    watch.Start();
                    for (int i = 0; i < n; i++)
                    {
    //                    var ret = fun3(xDen.Row(i));
                        var ret = fun3(DenseVector.OfEnumerable(xRaw[i]));
                    }
                    watch.Stop();
                    log.InfoFormat("Math.Net took {0} seconds.", watch.Elapsed.TotalSeconds);
                }
     NumericsTest   318 	 Round 0.
     NumericsTest   327 	 System array took 0.7008772 seconds.
     NumericsTest   336 	 ILNumerics took 1.9559407 seconds.
     NumericsTest   315 	 Math.Net took 5.2027841 seconds.
     NumericsTest   318 	 Round 1.
     NumericsTest   327 	 System array took 0.6791225 seconds.
     NumericsTest   336 	 ILNumerics took 0.4739782 seconds.
     NumericsTest   315 	 Math.Net took 4.931067 seconds.
     NumericsTest   318 	 Round 2.
     NumericsTest   327 	 System array took 0.6734302 seconds.
     NumericsTest   336 	 ILNumerics took 0.470311 seconds.
     NumericsTest   315 	 Math.Net took 4.8086843 seconds.
     NumericsTest   318 	 Round 3.
     NumericsTest   327 	 System array took 0.6801929 seconds.
     NumericsTest   336 	 ILNumerics took 0.471479 seconds.
     NumericsTest   315 	 Math.Net took 4.8423348 seconds.
     NumericsTest   318 	 Round 4.
     NumericsTest   327 	 System array took 0.6761803 seconds.
     NumericsTest   336 	 ILNumerics took 0.4709513 seconds.
     NumericsTest   315 	 Math.Net took 4.7920563 seconds.
     NumericsTest   318 	 Round 5.
     NumericsTest   327 	 System array took 0.6820961 seconds.
     NumericsTest   336 	 ILNumerics took 0.471545 seconds.
     NumericsTest   315 	 Math.Net took 4.7798939 seconds.
     NumericsTest   318 	 Round 6.
     NumericsTest   327 	 System array took 0.6779479 seconds.
     NumericsTest   336 	 ILNumerics took 0.4862169 seconds.
     NumericsTest   315 	 Math.Net took 4.5421089 seconds.
     NumericsTest   318 	 Round 7.
     NumericsTest   327 	 System array took 0.6760993 seconds.
     NumericsTest   336 	 ILNumerics took 0.4704415 seconds.
     NumericsTest   315 	 Math.Net took 4.8233003 seconds.
     NumericsTest   318 	 Round 8.
     NumericsTest   327 	 System array took 0.6759367 seconds.
     NumericsTest   336 	 ILNumerics took 0.4710648 seconds.
     NumericsTest   315 	 Math.Net took 4.7945989 seconds.
     NumericsTest   318 	 Round 9.
     NumericsTest   327 	 System array took 0.6761679 seconds.
     NumericsTest   336 	 ILNumerics took 0.4779321 seconds.
     NumericsTest   315 	 Math.Net took 4.7426801 seconds.
