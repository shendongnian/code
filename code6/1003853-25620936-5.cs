    public static string ExtractName(this string @string, NameOptions nameOptions)
    {
        
        switch (nameOptions)
        {
            case NameOptions.FirstName:
                return ResolveFirstName(@string);
            case NameOptions.MiddleName:
                return ResolveMiddleName(@string);
            case NameOptions.LastName:
                return ResolveLastName(@string);
            default:
                throw new NotSupportedException("Name " + nameOptions + " is not supported.");
        }
    }
