    Page.Validators.Add(new CustomValidator()
    {
        Display = ValidatorDisplay.Dynamic,
        ControlToValidate = ContactTelephoneTextBox.ClientID, 
        ID = "phoneInvalid",
        IsValid = false,
        ErrorMessage = "Please enter a valid phone number.", 
        field",
    });
