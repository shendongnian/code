    public bool HasErrors
    {
        get
        {
            return this.Select(x => x as IDataErrorInfo)
                       .Where(x => x != null && x.Error != null)
                       .Count() > 0;
        }
    }
