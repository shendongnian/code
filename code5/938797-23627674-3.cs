    public class RankItem
    {
        public Guid ModID { get; set; }
        public string Code { get; set; }
        public string RankName { get; set; }
        public int? Priority { get; set; }
    
        public DataFields<string> StringDataFields {get;set;}  // I want to add dynamic field
        public  DataFields<AccountItem> AccountItemDataFields {get;set;}  // I want to add dynamic field
        //public DataFields<int> AnotherSampleDataList {get;set;}  // I want to add dynamic field
    }
