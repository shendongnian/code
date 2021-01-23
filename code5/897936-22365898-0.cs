    public class DropDownListModel
    {
        public string SelectedItem { get; set; }
        public IList<SelectListItem> Options { get; set; }
    }
    
    public class ContactModel
    {
        [UIHint("_DropDownList")]
        public DropDownListModel ContactTypeOptions { get; set; }
    }
