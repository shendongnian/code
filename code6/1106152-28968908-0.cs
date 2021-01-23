    public class Both : IScalar<string>, IScalar<double>
    {
        public string StringValue { get; set; }
        string IScalar<string>.Value
        {
            get
            {
                return StringValue;
            }
            set
            {
                this.StringValue = value;
            }
        }
        public double DoubleValue { get; set; }
        double IScalar<double>.Value
        {
            get
            {
                return DoubleValue;
            }
            set
            {
                DoubleValue = value;
            }
        }
        // other methods and properties left out
    }
