    public class ServiceSpecification
    {
        private const int BytesInWord = 8;
        public int? In { get; private set; }
        public int? Out { get; private set; }
        public static ServiceSpecification Parse(string s)
        {
            return new ServiceSpecification {
                In = ParseBytesCount(s, "In"),
                Out = ParseBytesCount(s, "Out")
            };
        }
        private static int? ParseBytesCount(string s, string direction)
        {
            var pattern = direction + @"(\d+)(bytes|words)";
            var match = Regex.Match(s, pattern);
            if (!match.Success)
                return null;
            int value = Int32.Parse(match.Groups[1].Value);
            return match.Groups[2].Value == "bytes" ? value : value * BytesInWord;
        }
        public bool IsSatisfiedBy(IService service)
        {
            if (In.HasValue && service.In != In.Value)
                return false;
            if (Out.HasValue && service.Out != Out.Value)
                return false;
            return true;
        }
    }
