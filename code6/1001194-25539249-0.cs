    public class UserType
    {
        [Key]
        public int id { get; set; }
    
        [Required, MaxLength(30, ErrorMessage = "Name can not be longer than 30 characters."), Display(Name = "User Type")]
        public string userType { get; set; }
    }
