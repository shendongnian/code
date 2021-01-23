    public class Size
    {
        public static Size Parse(string s)
        {
            Regex regex = new Regex(@"(?<value>\d+(\.\d+)?)\s*(?<units>\w+)\s*.*");
            var match = regex.Match(s);
            if (!match.Success)
                throw new ArgumentException("Unknown size format");
            return new Size {
                Value = Double.Parse(match.Groups["value"].Value),
                Units = GetSizeUnits(match.Groups["units"].Value)
            };
        }
        private static SizeUnit GetSizeUnits(string units)
        {
            switch (units.ToUpper())
            {      
                // sorry don't know how you define bytes in your system
                case "KB": return SizeUnit.Kilobyte;
                case "MB": return SizeUnit.Megabyte;
                case "GB": return SizeUnit.Gigabyte;
                case "TB": return SizeUnit.Terabyte;
                default: throw new ArgumentException("Unknown size units");
            }
        }
        public double Value { get; private set; }
        public SizeUnit Units { get; private set; }
        public double ValueInBytes
        {
            get { return Math.Pow(1024, (int)Units) * Value; }
        }
    }
