        public List<SelectListItem> usertype { get; set; }
            
        [Display(Name="User Type")]
        [Required(ErrorMessage = "Select user type")]
        public int UserType { get; set; }
