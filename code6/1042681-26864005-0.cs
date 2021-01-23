    public class ServerViewModel
    {
        // Display Attribute will appear in the Html.LabelFor
        [Display(Name = "Server")]
        public int SelectedserverId { get; set; }
        public IEnumerable<SelectListItem> ServerList { get; set; }
    }
