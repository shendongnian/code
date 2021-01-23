    /**
     * class used to optimize loggers
     *
     * Logger.Trace("info "+bigData.ToString());
     * Logger.Trace("info {0}",bigData.ToString());
     * both creates and parses bigData even if Trace is disabled
     * 
     * Logger.Trace("info {0}", LazyJsonizer.Create(bigData));
     * Logger.Trace(LazyJsonizer.Instance, "info {0}", bigData);
     * creates string only if Trace is enabled
     * 
     * http://stackoverflow.com/questions/23007377/nlog-serialize-objects-or-collections-to-log
     */
    public class LazyJsonizer<T>
    {
        T Value;
        public LazyJsonizer(T value)
        {
            Value = value;
        }
        override public string ToString()
        {
            return LazyJsonizer.Instance.Format(null, Value, null);
        }
    }
    public class LazyJsonizer : IFormatProvider, ICustomFormatter
    {
        static public readonly LazyJsonizer Instance = new LazyJsonizer();
        static public LazyJsonizer<T> Create<T>(T value)
        {
            return new LazyJsonizer<T>(value);
        }
        public object GetFormat(Type formatType)
        {
            return this;
        }
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            try
            {
                return JsonConvert.SerializeObject(arg);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
