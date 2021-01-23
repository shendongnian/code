    public override ObservableCollection<string> Errors
    {
        get
        {
            errors = new ObservableCollection<string>();
            errors.AddUniqueIfNotEmpty(this["Name"]);
            errors.AddUniqueIfNotEmpty(this["EmailAddresses"]);
            errors.AddUniqueIfNotEmpty(this["SomeOtherProperty"]);
            errors.AddRange(ExternalErrors);
            return errors;
        }
    }
    public override string this[string propertyName]
    {
        get
        {
            string error = string.Empty;
            if (propertyName == "Name" && Name.IsNullOrEmpty()) error = "You must enter the Name field.";
            else if (propertyName == "EmailAddresses" && EmailAddresses.Count == 0) error = "You must enter at least one e-mail address into the Email address(es) field.";
            else if (propertyName == "SomeOtherProperty" && SomeOtherProperty.IsNullOrEmpty()) error = "You must enter the SomeOtherProperty field.";
            return error;
        }
    }
