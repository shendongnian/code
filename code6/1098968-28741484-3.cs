       public static List<DomainModel> GetOtherDomains()
       {
        	var jsSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        	List<DomainModel> domainList = 
                       jsSerializer.ConvertToType<List<DomainModel>>(list);        
            return domainList;        
       }
