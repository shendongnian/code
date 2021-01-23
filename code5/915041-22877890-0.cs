    public bool IsVar
    {
        get
        {
            var ts = this.Green as InternalSyntax.IdentifierNameSyntax;
            return ts != null && ts.Identifier.ToString() == "var";
        }
    }
