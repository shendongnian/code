    public class PartsMatchResponse
    {
        public List<PartsMatchResult> results { get; set; }
    }
    public class PartsMatchResult
    {
        public List<Part> items { get; set; }
    }
    public class Part
    {
        public Manufacturer manufacturer { get; set; }
        public string mpn { get; set; }
        public Dictionary<string, AbstractQValue> specs { get; set; }
    }
    public class Manufacturer
    {
        public string name { get; set; }
    }
    public abstract class AbstractQValue
    {
        public List<string> value { get; set; }
    }
    public class QualitativeValue : AbstractQValue
    {
    }
    public class QuantitativeValue : AbstractQValue
    {
        public string unit { get; set; }
    }
