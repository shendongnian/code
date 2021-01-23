    public class Measurement
    {
        public string DisplayName { get; private set; }
        private Measurement(string displayName)
        {
            this.DisplayName = displayName;
        }
        public static readonly Measurement Grams = new Measurement("Grams");
        public static readonly Measurement FluidOunces = new Measurement("Fluid Ounces");
        ...
    }
