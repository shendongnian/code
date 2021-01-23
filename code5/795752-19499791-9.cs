    public override string this[string propertyName]
    {
        get
        {
            string error = string.Empty;
            if (propertyName == "FooObject" && FooObject.GetType() != typeof(int)) 
                error = "Please enter a whole number for the Foo field.";
            ...
            return error;
        }
    }
