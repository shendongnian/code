    [Route("{companyID:int}/contact/")]
    [HttpGet]
    public IQueryable GetCompanyContactsByID(int companyID)
    {
        IQueryable<vwCompanyContact> contact
            = coreDB.vwCompanyContacts.Where(con => con.IDCompany == companyID);
        return contact;
    }
    [Route("{companyID:int}/contact/{uid}")]
    [HttpGet]
    public IQueryable GetCompanyContactsByID(int companyID, Guid uid)
    {
        IQueryable<vwCompanyContact> contact
            = coreDB.vwCompanyContacts.Where(con => con.IDCompany == companyID
                                                    && con.CatalogNumber == uid);
    
        return contact;
    }
