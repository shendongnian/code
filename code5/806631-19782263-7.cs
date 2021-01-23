    public class NewRegistrationModel {
    
        [System.ComponentModel.DisplayName("Profile Display Name")]
        [UIHint("DisplayName")]
        public string DisplayName { get; set; }
    
        [System.ComponentModel.DisplayName("Email Address")]
        [UIHint("EmailAddress")]
        public string EmailAddress1 { get; set; }
    
        [System.ComponentModel.DisplayName("Email Address (confirm)")]
        [UIHint("EmailAddress")]
        public string EmailAddress2 { get; set; }
    
    }
