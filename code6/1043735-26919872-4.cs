    [DataMember]
    [DisplayName("Approved By")]
    [ConditionalRequired("HOA", "ApprovedDate")]
    [StringLength(50, ErrorMessage = "{0} must not exceed {1} characters")]
    public string ApprovedBy { get; set; }
