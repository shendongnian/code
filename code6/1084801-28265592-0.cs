    public class MessageViewModel
    {
        [Required]
        [RegularExpression(@"^(?!.*<[^>]+>).*", ErrorMessage = "No html tags allowed")]
        public string UserName { get; set; }
    }
