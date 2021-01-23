    public class TestViewModel
    {
        [Required]
        [Display(Name = "Work section")]
        // This represents the selected ID on the dropdown
        public int WorkSectionId { get; set; }
        // The dropdown itself
        public SelectList WorkSections { get; set; }
        // other properties
    }
