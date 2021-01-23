    public class Summary
    {
        public int RowNumber {get; set;}
        public int TotalRows {get; set;}
        public int TotalDisplayRows {get; set;}
    }
    
    Summary pt=new Summary();
    pt.TotalRecords=10;
    pt.TotalDisplayRecords=10;
    pt.RowNumber=1;
    string json=JsonConvert.SerializeObject(pt);
