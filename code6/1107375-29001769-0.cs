    public class Paging
    {
        public int CurPage { get; set; }
        public int TotalPageCount { get; set; }
    }
    public class Item
    {
        public int T0 { get; set; }
        public string T2 { get; set; }
    }
    var lst = new List<object>();
    lst.Add(new Paging());
    lst.Add(new Item());
    JsonConvert.SerializeObject(lst);
