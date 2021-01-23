    public class EditViewModel
    {
        [DisplayName("Display Name:")]
        [Required]
        public int AnIntProp { get; set; }
        [DisplayName("Another Display Name:")]
        [Required]
        public string HereIsAString { get; set; }
        [DisplayName("Bool Display:")]
        [Required]
        public bool ImABool{ get; set; }
    }
