    public class DTO 
    {
        public string Monthly { get; set; }
        public string Name { get; set; }
        public string Test { get; set; }
    }
    var d = new DTO() {
        Monthly = "value1",
        Name = "value2",
        Test = "value3"
    };
    // Using JSON.Net
    var json = JsonConvert.SerializeObject(d);
