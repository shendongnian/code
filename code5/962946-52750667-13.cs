    public partial class USERS
    {
        [Key]
        public int USER_ID { get; set; }
        [Required]
        [StringLength(30)]
        public string USER_NAME { get; set; }
    }
