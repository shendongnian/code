 System.ComponentModel.DataAnnotations.ValidationContext.set_DisplayName(String value) +48859
and then you have this
        [Display(Name = "")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "Titlen skal være på mellem 6 og 50 tegn")]
        public String Semester { get; set; }
It is not null but maybe removing empty value helps.
   
