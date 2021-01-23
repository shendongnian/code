    public class WebApiEntity
    {
        public Collection<CData> data { get; set; }
        public Collection<(String CType, String CId)> data_tuple { get; set; } 
    }
    public struct CData
    {
        public string CType { get; set; }
        public string CId { get; set; }
    }
