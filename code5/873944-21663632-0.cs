    public bool HasErrors
    {
        get
        {
            return this.OfType<IDataErrorInfo>().Any(x => x.Error != null);
        }
    }
