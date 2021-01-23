    public struct ComplexNumber<T>
    {
        private readonly T _realPart;
        private readonly T _imaginaryPart;
        public ComplexNumber(T realPart, T imaginaryPart)
        {
            _realPart = realPart;
            _imaginaryPart = imaginaryPart;
        }
        public T RealPart
        {
            get
            {
                return _realPart;
            }
        }
        public T ImaginaryPart
        {
            get
            {
                return _imaginaryPart;
            }
        }
        public override string ToString()
        {
            return string.Format("({0}, {1})", RealPart, ImaginaryPart);
        }
    }
    public static class ComplexNumberExtensions
    {
        public static ComplexNumber<int> Add(this ComplexNumber<int> self, ComplexNumber<int> other)
        {
            return new ComplexNumber<int>(self.RealPart + other.RealPart, self.ImaginaryPart + other.ImaginaryPart);
        }
        public static ComplexNumber<double> Add(this ComplexNumber<double> self, ComplexNumber<double> other)
        {
            return new ComplexNumber<double>(self.RealPart + other.RealPart, self.ImaginaryPart + other.ImaginaryPart);
        }
        // Add similar extension methods for each numeric type you need
    }
