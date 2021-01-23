    }
    [Display(Name = "Password", Prompt = "Password"), Required(), DataType(DataType.Password), StringLength(255, MinimumLength = 5, ErrorMessage = "The password must be at least 7 characters")]
    public string Password { get; set; }
    [Display(Name = "Confirm Password", Prompt = "Confirm Password"), Compare("Password", ErrorMessage = "Your confirmation doesn't match...")]
    public string PasswordConfirmation { get; set; }
}
