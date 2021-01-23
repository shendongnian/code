    public override string FormatErrorMessage(string name) {
        this.EnsureLegalLengths();
    
        bool useErrorMessageWithMinimum = this.MinimumLength != 0 && !this.CustomErrorMessageSet;
    
        string errorMessage = useErrorMessageWithMinimum ?
            DataAnnotationsResources.StringLengthAttribute_ValidationErrorIncludingMinimum : this.ErrorMessageString;
    
        // it's ok to pass in the minLength even for the error message without a {2} param since String.Format will just
        // ignore extra arguments
        return String.Format(CultureInfo.CurrentCulture, errorMessage, name, this.MaximumLength, this.MinimumLength);
    }
