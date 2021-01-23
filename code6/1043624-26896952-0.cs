    public class CheckInViewModel
    {
        [Required(ErrorMessage = "Location Required.")]
        public int CheckIn_Location_Selected { get; set; } 
        
        public IEnumerable<SelectListItem> CheckIn_Location_List { get; set; }
        //Rest of the properties...
    }
