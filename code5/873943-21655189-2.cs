    public bool HasErrors
    {
        get
        {
            return this.Select(x => x as IDataErrorInfo)
                       .Any(x => x != null && x.Error != null);
        }
    }
