    public class InvalidFileFormatException : System.FormatException
    {
        public InvalidFileFormatException(string exText) : base(exText) { }
    }
    // you could even provide an exception if a single line has an invalid format
    public class SpecificLineErrorException : InvalidFileFormatException 
    {
        public string Line { get; set; }
        public SpecificLineErrorException(string exText, string line) : base(exText) 
        {
            this.Line = line;
        }
    }
