    public class LogonInfo
    {
        [Required]
        [MinLength(10)]
        public string Email { get; set; }
         
        public string Password { get; set; }
    }
