    public class BranchByBranchId
    {
        public int id { get; set; }
        public int institution_id { get; set; }
        public string branch_name { get; set; }
    }
    
    public class Record
    {
        public int id { get; set; }
        public string full_name { get; set; }
        public string email { get; set; }
        public int branch_id { get; set; }
        public BranchByBranchId Branch_by_branch_id { get; set; }
    }
    
    public class RootObject
    {
        public List<Record> record { get; set; }
    }
