    public virtual AccountType? AccountType
    {
        get
        {
            AccountType type;
            if (Enum.TryParse(AccountTypeString, out type))
                return type
            return null;
        }
        set
        {
            AccountTypeString = String.IsNullOrWhitespace(value) ? null : value.ToString();
        }
    }
