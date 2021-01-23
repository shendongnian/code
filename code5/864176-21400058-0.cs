    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Text;
    namespace empty 
    {
        class Program
        {
            double[, , ,] info = new double[100, 100, 10, 5];
            void calculate()
            {
                try
                {
                    for (int row = 0; row < 100; row++)
                    {
                        Parallel.For(0, 99, col =>
                        {
                            double result;
                            int tempcol = col;
                            for (int layer = 0; layer < 10; layer++)
                            {
                                int templayer = layer;
                                for (int tex_class = 0; tex_class < 5; tex_class++)
                                {
                                    int tempclass = tex_class;
                                    result = info[row, tempcol, templayer, tempclass];
                                }
                                //other code
                            }
                        });
                    }
                }
                catch { }
            }
            static void Main(string[] args)
            {
                calculate();
            }
        }
    }
