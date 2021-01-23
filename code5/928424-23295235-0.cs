    public class PageTotals
    {
        public int TotalRecords {get; set;}
        public int TotalDisplayRecords {get; set;}
    }
    
    PageTotals pt=new Pagetotals();
    pt.TotalRecords=10;
    pt.TotalDisplayRecords=10;
    string json=JsonConvert.SerializeObject(pt);
