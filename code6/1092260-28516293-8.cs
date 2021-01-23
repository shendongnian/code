    private DbContext _oDbContextField;
    private DbContext _oDbContext
    {
        get{
            if(_oDbContextField == null)
            {
                _oDbContext = _oDataBaseContext.dbContext();
            } 
            return _ODbContext;
        }
    }
