    public override ObservableCollection<string> Errors
    {
        get
        {
            errors = new ObservableCollection<string>();
            errors.AddUniqueIfNotEmpty(this["Name"]);
            errors.AddUniqueIfNotEmpty(this["EmailAddresses"]);
            errors.AddUniqueIfNotEmpty(this["StatementPrefixes"]);
            errors.AddRange(ExternalErrors);
            return errors;
        }
    }
