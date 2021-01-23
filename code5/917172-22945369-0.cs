        public class SqlFormat : IFormatProvider, ICustomFormatter
        {
            public object GetFormat(Type formatType)
            {
                if (formatType == typeof(ICustomFormatter))
                    return this;
                return null;
            }
            internal int IndexCounter = 0;
            Dictionary<string, int> dict = new Dictionary<string, int>();
            public string Format(string format, object arg, IFormatProvider formatProvider)
            {
                if (!this.Equals(formatProvider))
                    return null;
                if (string.IsNullOrEmpty(format))
                    format = "SQL";
                var formats = format.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                format = formats[0];
                if (format == "SQL")
                {
                    string ind = IndexCounter.ToString();
                    if (dict.ContainsKey(formats[1])) ind = dict[formats[1]].ToString();
                    else dict.Add(formats[1], IndexCounter++);
                    var pName = "@p" + ind;
                    return pName + (formats.Length > 1 ? " /* " + formats[1] + " */" : "");
                }
                else
                {
                    return HandleOtherFormats(format, arg);
                }
            }
            public string HandleOtherFormats(string format, object arg)
            {
                return string.Format(format, arg);
            }
        
