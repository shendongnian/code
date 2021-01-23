    public class ReportModel
    {
        public DateType DateType { get; set; }
        [Required(ErrorMessage = "Dit veld is verplicht")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CustomDateFrom { get; set; }
        [Required(ErrorMessage = "Dit veld is verplicht")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CustomDateTo { get; set; }
        public List<TypeDTO> DateTypesDTO { get; set; }
    }
