    @model  UserRegisterViewModel
    
    @Html.LabelFor(model => model.User.Password)
    @Html.EditorFor(model => model.User.Password)
    @Html.ValidationMessageFor(model => model.User.Password)
    
    @Html.LabelFor(model => model.CPassword)
    @Html.EditorFor(model => model.CPassword)
    @Html.ValidationMessageFor(model => model.CPassword)
    public class User
    {
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    
    public class UserRegisterViewModel
    {
        public User User { get; set; }
        public string Password{get { return this.User.Password; }}
    
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords must match")]
        [Required(ErrorMessage = "Confirm password is required")]
        [DisplayName("Confirm Password")]
        public string CPassword { get; set; }
    }
