    [MetadataTypeAttribute(typeof(OrganisationEditViewModelMetaData))]
    public partial class OrganisationEditViewModel
    {
    
    }
    
    public class OrganisationEditViewModelMetaData
    {
        [Key]
        [ScaffoldColumn(false)]
        [HiddenInput(DisplayValue = false)]
        public int entityID { get; set; }
    
        [Required]
        [Display(Name = "Organisation")]
        public string entityName { get; set; }
    
        [Required]
        [Display(Name = "Entity Type")]
        [UIHint("_dropDownEdit")]
        public DropDownViewModel entityTypeID { get; set; }
    
        [Display(Name = "Notes")]
        public string notes { get; set; }
    
    }
