    public class Registration
    {
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [DataType(DataType.Password), Required] public string Password { get; set; }
        [Required] public string Password2 { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Phone { get; set; }
    }
