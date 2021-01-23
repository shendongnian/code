    public class TestModel
    {
        public int AgeMin { get; set; }
        public int AgeMax { get; set; }
        public List<int> MaritalStatuses { get; set; }
    
        public string ToQueryString()
        {
            return string.Format("AgeMin={0}&AgeMax={1}&MaritialStatuses={2}", 
                                AgeMin, AgeMax, string.Join(",", MaritalStatuses));
        }
    }
