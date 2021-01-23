       public static List<DomainModel> GetOtherDomains()
       {
            List<dynamic> list = BusinessFactory.tblDomain.GetOtherDomains(Sessions.LoginID);
        	var jsSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        	List<DomainModel> domainList = 
                       jsSerializer.ConvertToType<List<DomainModel>>(list);        
            return domainList;        
       }
