    [Route("{companyID:int}/contact/{uid?}")]
    [HttpGet]
    public IQueryable GetCompanyContactsByID(int companyID, string uid = null)
    {
        Guid? uidValue = null;
        if(!string.IsNullOrEmpty(uid) && !Guid.TryParse(uid, out uidValue))
             throw new ArgumentException("uid");
        IQueryable<vwCompanyContact> contact
            = coreDB.vwCompanyContacts.Where(con => con.IDCompany == companyID);
    
            if (uidValue.HasValue)
                contact = contact.Where(con => con.CatalogNumber == uidValue.Value);
    
        return contact;
    }
