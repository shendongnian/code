    [Table("UserAddress")]
    public class UserAddress
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserAddressId{ get; set; }
        // foreign key to UserProfile
        public int UserProfileId { get; set; }
        // navigation property to UserProfile
        public UserProfile Profile { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
