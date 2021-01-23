    private bool ValidateAll(IList<string> errorMessages)
    {
        return IsUsernameAvailable(errorMessages)
             | IsUsernameValid(errorMessages)
             | IsPasswordComplexEnough(errorMessages)
             | ArePasswordAndConfirmationEquals(errorMessages);
    }
