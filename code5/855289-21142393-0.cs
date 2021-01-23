    public override string this[string propertyName]
    {
        get
        {
            string error = string.Empty;
            if (propertyName == "PinNumber" && RequirePinNumber && 
                string.IsNullOrEmpty(PinNumber)) 
                    error = "You must enter the PinNumber field.";
            ...
            return error;
        }
    }
