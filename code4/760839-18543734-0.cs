    public struct Temperature: IComparable
    {
        #region fields
        double value;
        TemperatureUnit unit;
        #endregion fields
        #region constructors
        public Temperature(double value, TemperatureUnit unit)
        {
            AssertUnitNotNull(unit);
            AssertValueNotBelowAbsZero(value, unit);
            this.value = value;
            this.unit = unit;
        }
        public Temperature(Temperature temp, TemperatureUnit unit)
        {
            AssertUnitNotNull(unit);
            this.value = ConvertUnit(temp.value, temp.unit, unit);
            this.unit = unit;
        }
        #endregion constructors
        #region properties
        public double Value
        {
            get { return this.value; }
            set 
            {
                AssertValueNotBelowAbsZero(value, this.unit);
                this.value = value; 
            }
        }
        public TemperatureUnit Unit
        {
            get { return this.unit; }
            set 
            {
                AssertUnitNotNull(value);
                if (this.unit != value)
                {
                    this.value = ConvertUnit(this.value, this.unit, value);
                    this.unit = value;
                }
            }
        }
        #endregion properties
        #region methods
        #region overridden methods
        public override bool Equals(object obj)
        {
            return this.CompareTo(obj) == 0;
        }
        public override int GetHashCode()
        {
            return this.unit.ToKelvin(value).GetHashCode();
        }
        const string OutputFormat = "{0}{1}";
        public override string ToString()
        {
            return string.Format(OutputFormat, this.value, this.unit.Symbol);
        }
        #endregion overridden methods
        public int CompareTo(object obj)
        {
            Temperature? t = obj as Temperature?;
            if (!t.HasValue) return -1;
            return this.unit.ToKelvin(value).CompareTo(t.Value.unit.ToKelvin(t.Value.value));   
        }
        #region operator overloads
        public static Temperature operator +(Temperature a, double b)
        {
            return new Temperature(a.value + b, a.unit);
        }
        public static Temperature operator +(Temperature a, Temperature b)
        {
            return a + ConvertUnit(b.value, b.unit, a.unit);
        }
        public static Temperature operator +(Temperature a, TemperatureUnit b)
        {
            return new Temperature(a, b);
        }
        public static Temperature operator -(Temperature a, double b)
        {
            return new Temperature(a.value - b, a.unit);
        }
        public static Temperature operator -(Temperature a, Temperature b)
        {
            return a - ConvertUnit(b.value, b.unit, a.unit);
        }
        public static Temperature operator ++(Temperature a)
        {
            return new Temperature(a.value + 1.0, a.unit);
        }
        public static Temperature operator --(Temperature a)
        {
            return new Temperature(a.value - 1.0, a.unit);
        }
        public static Temperature operator /(Temperature a, double b)
        {
            return new Temperature(a.value / b, a.unit);
        }
        public static Temperature operator *(Temperature a, double b)
        {
            return new Temperature(a.value * b, a.unit);
        }
        #endregion operator overloads
        #region helper methods
        private static double ConvertUnit(double value, TemperatureUnit from, TemperatureUnit to)
        {
            return to.FromKelvin(from.ToKelvin(value));
        }
        #endregion helper methods
        #endregion methods
        #region static validation methods
        private static void AssertUnitNotNull(TemperatureUnit unit)
        {
            if (unit == null) throw new ArgumentNullException();
        }
        private static void AssertValueNotBelowAbsZero(double value, TemperatureUnit unit)
        {
            if (unit.ToKelvin(value) < 0.0) throw new TemperatureIsBelowAbsoluteZeroException(value,unit);
        }
        #endregion static validation methods
    }
    public sealed class TemperatureUnit
    {
        #region delegate definitions
        delegate double Conversion(double source);
        #endregion delegate definitions
        #region attributes
        readonly string name;
        readonly string symbol;
        //base all functions around Kelvin since that allows us to restrict values to zero and above
        readonly Conversion fromKelvin;
        readonly Conversion toKelvin;
        #endregion attributes
        #region constructors
        private TemperatureUnit(string name, string symbol, Conversion fromKelvin, Conversion toKelvin)
        {
            this.name = name;
            this.symbol = symbol;
            this.fromKelvin = fromKelvin;
            this.toKelvin = toKelvin;
        }
        #endregion constructors
        #region properties
        public string Name { get { return this.name; } }
        public string Symbol { get { return this.symbol; } }
        #region defined units
        public static TemperatureUnit Kelvin = new TemperatureUnit("Kelvin", "\u212A", delegate(double d) { return d; }, delegate(double d) { return d; });
        public static TemperatureUnit Celcius = new TemperatureUnit("Celcius", "\u2103", KelvinToCelcius, CelciusToKelvin);
        public static TemperatureUnit Farenheit = new TemperatureUnit("Farenheit", "\u2109", KelvinToFarenheit, FarenheitToKelvin);
        public static TemperatureUnit Rankine = new TemperatureUnit("Rankine", "\u00B0Ra", KelvinToRankine, RankineToKelvin);
        public static TemperatureUnit Romer = new TemperatureUnit("R\u03B8mer", "\u00B0R\u03B8", KelvinToRomer, RomerToKelvin);
        public static TemperatureUnit Newton = new TemperatureUnit("Newton", "\u00B0N", KelvinToNewton, NewtonToKelvin);
        public static TemperatureUnit Delisle = new TemperatureUnit("Delisle", "\u00B0D", KelvinToDelisle, DelisleToKelvin);
        public static TemperatureUnit Reaumur = new TemperatureUnit("R\u00E9amur", "\u00B0R\u00E9", KelvinToReaumur, ReaumurToKelvin);
        #endregion defined units
        #endregion properties
        #region functions
        public double FromKelvin(double kelvin)
        {
            return this.fromKelvin(kelvin);
        }
        public double ToKelvin(double value)
        {
            return this.toKelvin(value);
        }
        #endregion functions
        #region overridden methods
        public override bool Equals(object obj)
        {
            TemperatureUnit tu = obj as TemperatureUnit;
            if (tu == null) return false;
            return this.name.Equals(tu.name);
        }
        public override int GetHashCode()
        {
            return this.name.GetHashCode();
        }
        public override string ToString()
        {
            return this.name.ToString();
        }
        #endregion overridden methods
        #region static conversion functions
        #region Celcius
        const double KelvinToCelciusOffset = -273.15;
        public static double CelciusToKelvin(double celcius)
        {
            return celcius - KelvinToCelciusOffset;
        }
        public static double KelvinToCelcius(double kelvin)
        {
            return kelvin + KelvinToCelciusOffset;
        }
        #endregion Celcius
        #region Fahrenheit
        //Fahrenheit	[°F] = [K] × 9⁄5 − 459.67	[K] = ([°F] + 459.67) × 5⁄9
        const double KelvinToFarenheitMultiplier = 9.0 / 5.0;
        const double KelvinToFarenheitOffset = -459.67;
        public static double FarenheitToKelvin(double farenheit)
        {
            return (farenheit - KelvinToFarenheitOffset) / KelvinToFarenheitMultiplier;
        }
        public static double KelvinToFarenheit(double kelvin)
        {
            return kelvin * KelvinToFarenheitMultiplier + KelvinToFarenheitOffset;
        }
        #endregion Fahrenheit
        #region Rankine
        const double KelvinToRankineMultiplier = KelvinToFarenheitMultiplier;
        public static double RankineToKelvin(double rankine)
        {
            return rankine / KelvinToRankineMultiplier;
        }
        public static double KelvinToRankine(double kelvin)
        {
            return kelvin * KelvinToRankineMultiplier;
        }
        #endregion Rankine
        #region Romer
        //[K] = ([°Rø] − 7.5) × 40⁄21 + 273.15	[°Rø] = ([K] − 273.15) × 21⁄40 + 7.5
        const double KelvinToRomerMultiplier = 21.0 / 40.0;
        const double KelvinToRomerOffset1 = KelvinToCelciusOffset;
        const double KelvinToRomerOffset2 = 7.5;
        public static double RomerToKelvin(double romer)
        {
            return (romer - KelvinToRomerOffset2) / KelvinToRomerMultiplier - KelvinToRomerOffset1;
        }
        public static double KelvinToRomer(double kelvin)
        {
            return (kelvin + KelvinToRomerOffset1) * KelvinToRomerMultiplier + KelvinToRomerOffset2;
        }
        #endregion Romer
        #region Newton
        //[K] = [°N] × 100⁄33 + 273.15	[°N] = ([K] − 273.15) × 33⁄100
        const double KelvinToNewtonMultiplier = 33.0 / 100.0;
        const double KelvinToNewtonOffset = KelvinToCelciusOffset;
        public static double NewtonToKelvin(double newton)
        {
            return (newton / KelvinToNewtonMultiplier) - KelvinToNewtonOffset;
        }
        public static double KelvinToNewton(double kelvin)
        {
            return (kelvin + KelvinToNewtonOffset) * KelvinToNewtonMultiplier;
        }
        #endregion Newton
        #region Delisle
        //[K] = 373.15 − [°De] × 2⁄3	[°De] = (373.15 − [K]) × 3⁄2
        const double KelvinToDelisleMultiplier = 1.5;
        const double KelvinToDelisleOffset = 373.15;
        public static double DelisleToKelvin(double delisle)
        {
            return KelvinToDelisleOffset - delisle / KelvinToDelisleMultiplier;
        }
        public static double KelvinToDelisle(double kelvin)
        {
            return (KelvinToDelisleOffset - kelvin) * KelvinToDelisleMultiplier;
        }
        #endregion Delisle
        #region Reaumur
        //[K] = [°Ré] × 5⁄4 + 273.15	[°Ré] = ([K] − 273.15) × 4⁄5
        const double KelvinToReaumurMultiplier = 4.0 / 5.0;
        const double KelvinToReaumurOffset = KelvinToCelciusOffset;
        public static double ReaumurToKelvin(double reaumur)
        {
            return reaumur / KelvinToReaumurMultiplier - KelvinToReaumurOffset;
        }
        public static double KelvinToReaumur(double kelvin)
        {
            return (kelvin + KelvinToReaumurOffset) * KelvinToReaumurMultiplier;
        }
        #endregion Reaumur
        #endregion static conversion functions
    }
    public class TemperatureIsBelowAbsoluteZeroException : Exception
    {
        public TemperatureIsBelowAbsoluteZeroException() : base() { }
        public TemperatureIsBelowAbsoluteZeroException(string message) : base(message) { }
        public TemperatureIsBelowAbsoluteZeroException(string message, Exception innerException) : base(message,innerException) { }
        public TemperatureIsBelowAbsoluteZeroException(System.Runtime.Serialization.SerializationInfo info,System.Runtime.Serialization.StreamingContext context) : base(info,context) { }
        
        const string ErrorMessageFormat = "Value '{0}{1}' is below absolute zero!";
        public TemperatureIsBelowAbsoluteZeroException(double value, TemperatureUnit unit) : base(string.Format(ErrorMessageFormat, value, unit.Symbol)) { }
    }
