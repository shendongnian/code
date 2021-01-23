    public class Employee : Person
    {
        [JsonProperty(Order = 1)]
        public int DepartmentId { get; set; }
        [JsonProperty(Order = 1)]
        public string Title { get; set; }
    }
