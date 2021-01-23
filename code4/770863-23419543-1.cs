    public class Random
    {
        MathNet.Numerics.Distributions.Normal _dist;
        int _min, _max, _mean;
        public Random(int mean, int min, int max)
        {
            _mean = mean;
            _min = min;
            _max = max;
            var stddev = Math.Min(Math.Abs(mean - min), Math.Abs(max - mean)) / 3.0;
            _dist = new MathNet.Numerics.Distributions.Normal(mean, stddev);
        }
        public int Next()
        {
            int next;
            do
            {
                next = (int)_dist.Sample();
            } while (next < _min || next > _max);
            return next;
        }
        public static int Next(int mean, int min, int max)
        {
            return new Random(mean, min, max).Next();
        }
    }
