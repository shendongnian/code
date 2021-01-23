    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
               ""result"":
                 {
                    ""car1"":{""lat"":37.989728,""long"":23.664633},
                    ""car2"":{""lat"":38.008027,""long"":23.774068}
                 }
            }";
            Result result = JsonConvert.DeserializeObject<Result>(json);
            foreach (KeyValuePair<string, Car> kvp in result.Cars)
            {
                Console.WriteLine(kvp.Key + ": lat=" + kvp.Value.Lat + 
                                            ", long=" + kvp.Value.Long);
            }
        }
    }
