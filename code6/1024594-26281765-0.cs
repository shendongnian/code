    public class LineErrorException : System.FormatException
    {
        public LineErrorException(string exText) : base(exText) { }
    }
    public class SpecificLineErrorException : LineErrorException
    {
        public SpecificLineErrorException(string exText) : base(exText) { }
    }
