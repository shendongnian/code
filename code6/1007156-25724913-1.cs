    public class Datum
    {
        public string ID { get; set; }
        public double M_CurBalanceOutstanding { get; set; }
    }
    
    public class DataDetail
    {
        public DateTime ErrorDate { get; set; }
        public int ErrorID { get; set; }
        public string ErrorInfo { get; set; }
    }
    
    public class RootObject
    {
        public List<Datum> Data { get; set; }
        public List<DataDetail> DataDetail { get; set; }
    }
