    static void Main(string[] args)
    {
        var now = DateTime.Now;
        var str = string.Format(new MyDateFormatter(), "The date is {0}", now);
        Console.WriteLine(str);
        MyDateFormatter.DefaultDateFormat = "dd-MM-yyyy HH:mm";
        str = string.Format(new MyDateFormatter(), "The date is {0}", now);
        Console.WriteLine(str);
    }
    public class MyDateFormatter: IFormatProvider, ICustomFormatter
    {
        public static string DefaultDateFormat = "yyyy-MM-dd";
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            return null;
        }
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            // Check whether this is an appropriate callback              
            if (!this.Equals(formatProvider))
                return null;
            var argFormat = "{0:" + (arg is DateTime ? DefaultDateFormat : string.Empty) + "}";
            return string.Format(argFormat, arg);
        }
    }
