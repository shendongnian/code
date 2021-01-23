    public enum Measurement
    {
        Grams,
        FluidOunces,
        ...
    }
    private static Dictionary<Measurement, string> displayName = new Dictionary<Measurement, string>
    {
        { Measurement.Grams, "Grams" },
        { Measurement.FluidOunces, "Fluid Ounces" },
        ...
    };
    public static string DisplayName(Measurement measurement)
    {
        return displayName[measurement];
    }
