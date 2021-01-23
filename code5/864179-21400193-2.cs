       class Program
        {
            double[, , ,] info = new double[100, 100, 10, 5];
    
            public void calculate()
            {
                double result;
                try
                {
                    Parallel.For(0, 100, row =>
                    {
                        for (int col = 0; col < 100; col++)
                        {
                            for (int layer = 0; layer < 10; layer++)
                            {
                                for (int tex_class = 0; tex_class < 5; tex_class++)
                                {
                                    result = info[row, col, layer, tex_class];
                                }
                                //other code
                            }
                        }
                    });
                }
                catch { }
            }
        } 
