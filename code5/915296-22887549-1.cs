    public class Measurement
    {
        public double MinimumX { get; set; }
        public double MinimumY { get; set; }
        public double Delta { get; set; }
        public IList<double> ActualValues { get; private set; }
        public Measurement() { this.ActualValues = new List<double>(); }
    }
    List<Measurement> measurements;
