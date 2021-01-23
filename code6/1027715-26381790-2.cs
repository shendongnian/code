    public class MyStaticProperties
    {
        public static Dictionary<string, marketdata> DataMap { get; set; };
    }
    // then you can access this in your button click events like htis
    MyStaticProperties.DataMap
