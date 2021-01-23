    interface IUserBase
    {
        [RegularExpression(@"^[a-zA-Z0-9$$!%*_\-#?&]*$", ErrorMessage = "The user name is invalid. Only letters, numbers, hyphens and underscores are allowed.")]
        string UserName { get; set; }
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.[a-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{7,20}$",
            ErrorMessage = "Password must contain a number, a lowercase character, an uppercase character, a special character and be between 7 and 20 characters in length.")]
        string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The new password and confirmation password do not match.")]
        string ConfirmPassword { get; set; }
    }
