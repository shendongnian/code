        static void Main(string[] args)
        {
            int value1 = GetValue<Int16>("23");
            double value2 = GetValue<double>("23.34");
        }
        public static T GetValue<T>(string value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }
