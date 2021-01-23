    public class MovementFormViewModel
    {
        public Movement Movement { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }
    
        [Required(ErrorMessage = "Location is required.")]
        public int SelectedLocation { get; set; }
        [Required(ErrorMessage = "Persons name is required.")]
        public int SelectedPerson { get; set; }
    
    }
