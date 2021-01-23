    public static List<DomainModel> GetOtherDomains()
    {
        List<DomainModel> list = new List<DomainModel>();
        List<DomainModel> items = BusinessFactory.tblDomain.GetOtherDomains(Sessions.LoginID);
    
        foreach (DomainModel item in items)
        {
            DomainModel model = new DomainModel();
    
            model.LoginID = item.LoginID;
            model.DomainID = item.CompanyID;
            model.CompanyName = item.CompanyName;
            model.RoleName = item.RoleName;
    
            list.Add(model);
        }
    
        return list;
    }
