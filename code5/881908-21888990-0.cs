    public class ProspectViewModel
    {
        public IEnumerable<SelectListItem> ProspectList { get; set; }
        
        [DisplayName("Product")] //This is for our label
        public int SelectedProspectId { get; set; }
    }
