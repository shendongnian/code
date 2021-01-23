    [MetadataType(typeof(WorksOrderMetaData))]
    public partial class WorksOrder
    {
    }
    public class WorksOrderMetaData
    {
        [Display(Name = "Created by")]
        [Required(ErrorMessage = "created by cannot be blank")]
        public string CreatedById { get; set; }
    }
