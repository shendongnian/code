    public class DataClass{
    public bool isIllegal{get;set;}
    public string Name { get; set; }
    public string Address { get; set; }
    public string ContactNo { get; set{isIllegal=!string.isNullOrEmpty(value);)}
    }
