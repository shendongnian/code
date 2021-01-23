    public bool HasErrors
    {
        get
        {
            return this.Select(x => x as IDataErrorInfo)
                       .Count(x => x != null && x.Error != null) > 0;
        }
    }
