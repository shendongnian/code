    using System.ComponentModel.DataAnnotations;
    
    public class TestModel{
        [EmailAddress]
        public string Email { get; set; }
    }
