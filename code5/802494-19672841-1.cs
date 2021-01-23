    public class Model
    {
        [Comparison("Value2", ComparisonType.LessThanOrEqual)]
        public int Value1 { get; set; }
        public int Value2 { get; set; }
    }
