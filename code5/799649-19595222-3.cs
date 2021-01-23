    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
                ""probability"": 0.01,
                ""mean"": 0,
                ""variance"": 0,
                ""min"": 0,
                ""max"": 0
            }";
            var tm = JsonConvert.DeserializeObject<Layer_Tail_Metrics>(json);
            Console.WriteLine("probability: " + tm.probability);
            Console.WriteLine("mean: " + tm.mean);
            Console.WriteLine("variance: " + tm.variance);
            Console.WriteLine("min: " + tm.min);
            Console.WriteLine("max: " + tm.max);
        }
        [DataContract]
        public class Layer_Tail_Metrics : Tail_Metrics 
        { 
        }
        [DataContract]
        public class Tail_Metrics
        {
            [DataMember(Order = 1, IsRequired = true)]
            public double probability { get; set; }
            [DataMember(Order = 2, IsRequired = true)]
            public double min { get; set; }
            [DataMember(Order = 3)]
            public double max { get; set; }
            [DataMember(Order = 4, IsRequired = true)]
            public double mean { get; set; }
            [DataMember(Order = 5)]
            public double variance { get; set; }
            [DataMember(Order = 6)]
            public double skewness { get; set; }
            [DataMember(Order = 7)]
            public double kurtosis { get; set; }
        }
    }
