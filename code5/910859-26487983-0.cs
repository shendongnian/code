    public class CreateDeviceInstance 
    {    
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public string SerialNo { get; set; }
        [Required(ErrorMessage="Data jest wymagana")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime CreationDate { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public bool Issue { get; set; }
        public string IssueDetails { get; set; }
        public Nullable<int> StorageId { get; set; }
        public bool MeAsUser { get; set; }
    }
