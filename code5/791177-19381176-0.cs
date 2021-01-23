    public class Test3Model
    {
        [Required]
        public SubmitAction  Submit { get; set; }
        public bool IsCancelPageChecked { get; set; }
    }
    public enum SubmitAction
    {
        None,
        ByItem,
        ByVendor,
        ByMember 
    }
