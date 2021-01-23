    class IntDataProcessor : IDataProcessor<int>
    {
        public int Process(int a, int b)
        {
            return a + b;
        }
    }
    
    class DoubleDataProcessor : IDataProcessor<double>
    {
        public double Process(double a, double b)
        {
            return a + b;
        }
    }
