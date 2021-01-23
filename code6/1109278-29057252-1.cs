    public class MyResponse
    {
       public IList<vwCompanyContct> myContacts {set;get;}
       public string ResponseMessage {set;get;}
    }
    
    [Route("{companyID:int}/contact/{uid?}")]
    [HttpGet]
    public MyResponse GetCompanyContactsByID(int companyID, Guid? uid = null)
    {
    var response = new MyResponse();
    
        IQueryable<vwCompanyContact> contacts = 
    coreDB.vwCompanyContacts.Where(con => (con.IDCompany == companyID) &&
                                          (uid == Guid.Empty || uid == CatalogNumber));
    
    if(!contacts.Any()) response.ResponseMessage = "No Results found";
    else
    {
     response.ResponseMessage = String.Format("{0} contact is found", contacts.Count());
     response.MyContacts = contacts.ToList();
    }
           
        return response ;
    }
