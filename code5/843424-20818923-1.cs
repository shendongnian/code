    var list2 = JsonConvert.DeserializeObject<List<Costs>>(json);
---
    public class Costs
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Sum { get; set; }
        public DateTime Date { get; set; }
    }
