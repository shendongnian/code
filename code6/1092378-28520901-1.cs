    var dict = JsonConvert.DeserializeObject<Dictionary<string, MyItem>>(json);
    public class MyItem
    {
        public string Description { get; set; }
        public int Cost { get; set; }
        public string Group { get; set; }
        public int WeldAngleDegrees { get; set; }
        public string Unit { get; set; }
        public double Width { get; set; }
        public int Thickness { get; set; }   
        public double Speed { get; set; }
        public double Setup { get; set; } 
    }
