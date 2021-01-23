    public static class Failable
    {
        public static StringToFailableConverter<Int32> Int32Converter { get; private set; }
        public static StringToFailableConverter<double> DoubleConverter { get; private set; }
        static Failable()
        {
            Int32Converter = new StringToFailableConverter<Int32>();
            DoubleConverter = new StringToFailableConverter<Double>();
        }
    }
