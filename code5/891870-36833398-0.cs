     public class BindDropDown
    {
        public Nullable<int> ID{ get; set; }
        [Required(ErrorMessage = "Enter name")]
        public string Name{ get; set; } 
    }
