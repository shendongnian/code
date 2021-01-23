    public static class MyExtensions
    {
        public static IFormattable Center<T>(this T self, int width)
        {
            return new CenterHelper<T>(self, width);
        }
        class CenterHelper<T> : IFormattable
        {
            readonly T value;
            readonly int width;
            internal CenterHelper(T value, int width)
            {
                this.value = value;
                this.width = width;
            }
            public string ToString(string format, IFormatProvider formatProvider)
            {
                string basicString;
                var formattable = value as IFormattable;
                if (formattable != null)
                    basicString = formattable.ToString(format, formatProvider) ?? "";
                else if (value != null)
                    basicString = value.ToString() ?? "";
                else
                    basicString = "";
                int numberOfMissingSpaces = width - basicString.Length;
                if (numberOfMissingSpaces <= 0)
                    return basicString;
                return new string(' ', numberOfMissingSpaces / 2) + basicString + new string(' ', numberOfMissingSpaces - numberOfMissingSpaces / 2);
            }
            public override string ToString()
            {
                return ToString(null, null);
            }
        }
    }
