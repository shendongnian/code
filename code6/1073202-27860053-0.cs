    public class TestModelViewModel
    {
        public int ParentId { get; set; }
        public IEnumerable<ParentListViewModel> ParentList { get; set; }
        
        public int ChildId { get; set; }
        
        public IEnumerable<ParentListViewModel> ChildList { get; set; }
        public IEnumerable<int> ChildIds { get; set; }
    }
    public class ParentListViewModel
    {
        public int Id { get; set; }
        
        public string Value { get; set; }
    }
    public class ChildListViewModel
    {
        public int ChildId { get; set; }
        
        public string ChildValue { get; set; }
    }
