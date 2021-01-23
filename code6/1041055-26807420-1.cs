    public class Rate
    {
        public int LogicId { get; set; }
        public string LineId { get; set; }
        public decimal Rate { get; set; }
        public bool IsChanged { get; set; }
    }
    public void Populate()
    {
        var rates = new List<Rate>();
        var rate = new Rate();
        rate.LogicId = 12;
        rate.LineId = string.Empty;
        rate.Rate = 0;
        rate.IsChanged = true;
        rates.Add(rate);
    }
    
