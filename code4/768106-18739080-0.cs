            // the input
            double[] dts = { 1, 2, 3, 4, 5 };
            double[] dt = { 10, 20, 30, 40, 50 };
            // list of lists, for iterating the input with LINQ
            double[][] combined = { dts, dt };
            var indexes = Enumerable.Range(0, dt.Length);
            var subIndexes = Enumerable.Range(0, 2);
            // the output
            var result = new double[dt.Length, 2];
            var sss = from i in indexes
                      from j in subIndexes
                      select result[i, j] = combined[j][i];
            // just to activate the LINQ iterator 
            sss.ToList();
