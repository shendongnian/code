    public enum IdentifierCase
    {
        Camel,
        Pascal,
    }
    public class CustomPropertyNamesContractResolver : DefaultContractResolver
    {
        private static readonly CultureInfo Culture = CultureInfo.InvariantCulture;
        public CustomPropertyNamesContractResolver (bool shareCache = false)
            : base(shareCache)
        {
            Case = IdentifierCase.Camel;
            PreserveUnderscores = true;
        }
        public IdentifierCase Case { get; set; }
        public bool PreserveUnderscores { get; set; }
        protected override string ResolvePropertyName (string propertyName)
        {
            return ChangeCase(propertyName);
        }
        private string ChangeCase (string s)
        {
            var sb = new StringBuilder(s.Length);
            bool isNextUpper = Case == IdentifierCase.Pascal, isPrevLower = false;
            foreach (var c in s) {
                if (c == '_') {
                    if (PreserveUnderscores)
                        sb.Append(c);
                    isNextUpper = true;
                }
                else {
                    sb.Append(isNextUpper ? char.ToUpper(c, Culture) : isPrevLower ? c : char.ToLower(c, Culture));
                    isNextUpper = false;
                    isPrevLower = char.IsLower(c);
                }
            }
            return sb.ToString();
        }
        // Json.NET implementation for reference
        private static string ToCamelCase (string s)
        {
            if (string.IsNullOrEmpty(s) || !char.IsUpper(s[0]))
                return s;
            var sb = new StringBuilder();
            for (int i = 0; i < s.Length; ++i) {
                if (i == 0 || i + 1 >= s.Length || char.IsUpper(s[i + 1]))
                    sb.Append(char.ToLower(s[i], Culture));
                else {
                    sb.Append(s.Substring(i));
                    break;
                }
            }
            return sb.ToString();
        }
    }
