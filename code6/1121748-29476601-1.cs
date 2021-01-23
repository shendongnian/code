    public struct Sample
    {
        public double StockPrice { get; set; }
    }
    public static class GlobalVar
    {
        public static Sample[] Samples = new Sample[10];
    }
