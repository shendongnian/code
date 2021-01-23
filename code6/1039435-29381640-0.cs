    [Validator(typeof(UserViewModelValidation))]
    public class UserViewModel {
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public String FullName { get; set; }
        public String CompanyName { get; set; }
    }
