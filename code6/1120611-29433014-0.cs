    public class MyCustomFormatter : IFormatProvider, ICustomFormatter
    {
        // Match "F_XX" where XX are digits.
        private readonly Regex _regex = new Regex("F_(?<DigitCount>\\d+)");
        // IFormatProvider.GetFormat implementation.
        public object GetFormat(Type formatType)
        {
            // Determine whether custom formatting object is requested.
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            var shouldUseF0 = false;
            
            var match = _regex.Match(format);
            if (match.Success)
            {
                // Manage float.
                if (arg is float)
                {
                    if (((float) arg)%1 == 0)
                    {
                        shouldUseF0 = true;
                    }
                }
                // Manage double.
                if (arg is double)
                {
                    if (((double) arg)%1 == 0)
                    {
                        shouldUseF0 = true;
                    }
                }
                // TODO: Manage int, long...
                if (shouldUseF0)
                {
                    format = "F0";
                }
                else
                {
                    format = "F" + match.Groups["DigitCount"];
                }
            }
            if (arg is IFormattable) return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            if (arg != null) return arg.ToString();
            return String.Empty;
        }
    }
