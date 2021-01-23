    public class Aggregation
    {
        public Aggregation(object sum, object average, int count)
        {
            Sum = sum;
            Average = average;
            Count = count;
        }
        public object Sum { get; private set; }
        public object Average { get; private set; }
        public int Count { get; private set; }
    }
