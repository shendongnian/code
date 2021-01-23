    private Expression<Func<BasketContents,bool>> IsSameID(string value)
    {
        return (Expression<Func<BasketContents,bool>>)(c => 
             ((c.ID == null || c.ID == "Default" || c.ID == "_" || c.ID == "") &&
              c.ID == value);              
    }
