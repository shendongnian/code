    public string GetPropertyByName(SectionsEnum s)
    {
        switch (s)
        {
            case SectionsEnum.FirstName:
                return this.FirstName;
            case SectionsEnum.MiddleName:
                return this.MiddleName;
            case SectionsEnum.LastName:
                return this.LastName;
            default:
                throw new Exception();
        }
    }
