    public class helper
    {
        public List<DoubleText> prop { get; set; }
    }
    public class DoubleText
    {
        public string data1 { get; set; }
        public object data2 { get; set; }
    }
    [WebMethod]
    public static string work(helper example)
    {
    // do stuff here
        return "ok";
    }
