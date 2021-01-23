    static class VectorExtensions
    {
        public static Vector<double> Real(this Vector<Complex> v)
        {
            return v.Map(x => x.Real);
        }
        public static Vector<double> Imag(this Vector<Complex> v)
        {
            return v.Map(x => x.Imaginary);
        }
    }
