    public class SonyResult
    {
    public int ID { get; set; }
    public string TYPE { get; set; }
    public string TITLE { get; set; }
    public string PRICE { get; set; }
    public string IMAGE { get; set; }
    }
    public class WindowsResult
    {
    public int ID { get; set; }
    public string TYPE { get; set; }
    public string TITLE { get; set; }
    public string PRICE { get; set; }
    public string IMAGE { get; set; }
    }
    public class RootObject
    {
    public List<SonyResult> SonyResult { get; set; }
    public int success { get; set; }
    public List<WindowsResult> WindowsResult { get; set; }
    }
    
