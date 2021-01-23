    public class Field
    {
        public string Name { get; set; } // Should ultimately be an enum.
        public string Value { get; set; }
        public Regex RegexValue
        {
            get {
                return _regexValue ?? (_regexValue = 
                    new Regex(Value, RegexOptions.Compiled | RegexOptions.IgnoreCase));
            }
        }
        private Regex _regexValue;
    }
    private bool FieldMatch(Field field)
    {
        var propValue = GetPropertyValue(field.Name);
        var stringMatch = string.Compare(propValue, field.Value, StringComparison.InvariantCultureIgnoreCase);
        return (stringMatch == 0) || field.RegexValue.IsMatch(propValue);
    }
