    public class CustomerFormatter : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }
        public string Format(string format,
                              object arg,
                              IFormatProvider formatProvider)
        {
            if (!this.Equals(formatProvider))
            {
                return null;
            }
            else
            {
                // generic formatter if no formater specified
                if (String.IsNullOrEmpty(format))
                    format = "G";
                // not a decimal type object
                if (!(arg is decimal))
                    return null;
                // get value
                decimal val = (decimal)arg;
                // convert value into generic culture string for control of format
                string valueString = val.ToString();
                // get string in required format type
                format = format.ToUpper();
                switch (format)
                {
                    // our user format
                    case "U":
                        // get decimals
                        string decimals = val.ToString("G", CultureInfo.InvariantCulture);
                        decimals = decimals.Substring(decimals.IndexOf('.') + 1);
                        // get current culture info
                        NumberFormatInfo nfi = new CultureInfo(CultureInfo.CurrentCulture.Name).NumberFormat;
                        // set our separators
                        nfi.NumberGroupSeparator = ",";
                        nfi.NumberDecimalSeparator = ".";
                        // set numebr of decimals
                        nfi.NumberDecimalDigits = decimals.Length;
                        // convert value to our format
                        valueString = val.ToString("N", nfi);
                        break;
                    default:
                        break;
                }
                return valueString;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            decimal dec = 32445.324777M;
            Console.WriteLine(String.Format(new CustomerFormatter(), "{0}", dec));
            Console.WriteLine(String.Format(new CustomerFormatter(), "{0:G}", dec));
            Console.WriteLine(String.Format(new CustomerFormatter(), "{0:U}", dec));
            Console.WriteLine(String.Format(new CustomerFormatter(), "{0:T}", dec));
            Console.ReadLine();
        }
    }
