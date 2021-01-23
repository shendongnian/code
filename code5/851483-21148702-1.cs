    protected void Initialize()
    {
        // Rest of code...
        InitializeLazyVars();
        /* We need do nothing here because instantiating the class object already set up default values. */
        foreach (var fi in GetLazyFields())
        {
            if (fi.GetValue(this) == null)
                throw new NotImplementedException("No initialization found for Lazy<T> " + fi.Name + " in class " + this.GetType());
        }
    }
