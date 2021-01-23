    string nameError = "Enter Name";
    ...
    public override string this[string propertyName]
    {
        get
        {
            string error = string.Empty;
            if (propertyName == "Name" && Name == string.Empty) error = nameError;
            else if (propertyName == "Age" && Age < 18) error = "You're too young";
            return error;
        }
    }
    public bool HasNameError
    {
        return Error == nameError;
    }
