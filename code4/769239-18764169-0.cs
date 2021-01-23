    public class DeleteModel
    {
    
        public string DeleteBy { get; set; }
   
        [Display(Name = "By Item")]
        public string ByItem { get; set; }
    
        [Display(Name = "By Vendor")]
        public string ByVendor { get; set; }
    
        [Display(Name = "By Member")]
        public string ByMember { get; set; }
    
        [Display(Name = "Cancel Page")]
        public string CancelPage { get; set; }
    
    }
