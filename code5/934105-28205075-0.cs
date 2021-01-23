    public class MyModel:BaseModel
    {
        [Required(ErrorMessage = "*")]
        [Display(ResourceType = typeof(RES.labels),Name = "lblLanguageCode")]
        public string LanguageCode { get; set; }
        
        [Required(ErrorMessage = "*")]
        [Display(ResourceType = typeof(RES.labels), Name = "lblCountryCode")]
        public string CountryCode{ get; set; }
    ...
    }
