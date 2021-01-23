    void Main()
    {
    	var list = GetDynamicObjects();	
        // Linqpad output
        list.Dump();
    	var jsSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
    	List<DomainModel> domainList = jsSerializer.ConvertToType<List<DomainModel>>(list);
        domainList.Dump();
    
    }
    
    
    private List<dynamic> GetDynamicObjects()
    {
        List<dynamic> list = new List<dynamic>();
    	list.Add(GetDynamicObject(1));
    	list.Add(GetDynamicObject(2));
    	return list;
    }
    
    private dynamic GetDynamicObject(int id)
    {
    	dynamic dyno = new System.Dynamic.ExpandoObject();
    	dyno.LoginID  = "LoginID" + id;
    	dyno.DomainID  = "DomainID"+ id;
    	dyno.CompanyName  = "CompanyName"+ id;
    	dyno.RoleName = "RoleName"+ id;
    	return dyno;
    }
    
    public class DomainModel
    {
    	public string LoginID { get;set; }
    	public string DomainID { get;set; }
    	public string CompanyName { get;set; }
    	public string RoleName { get;set; }
    }
