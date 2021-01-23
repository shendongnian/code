        static void Main(string[] args)
        {
            TypeDescriptor.AddAttributes(typeof(double), new TypeConverterAttribute(typeof(DoubleConverterEx)));
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(double));
            string number = "334,475.79";
            double num = (double)converter.ConvertFrom(number);
            Console.WriteLine(num);
        }
