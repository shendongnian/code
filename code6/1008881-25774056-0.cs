    public class TipViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        public int? SelectedPartnerId { get; set; }
        public IEnumerable<SelectListItem> PartnerChoices { get; set;}
        [Required]
        public int? SelectedBookId { get; set; }
        public IEnumerable<SelectListItem> BookChoices { get; set; }
    }
