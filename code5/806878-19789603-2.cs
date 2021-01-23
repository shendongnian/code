    using System.Web.Script.Serialization; // (in System.Web.Extensions.dll)
    
    ...
    
    string s = "[{\"ta_id\":97497,\"partner_id\":\"229547\",\"partner_url\":\"http://partner.com/deeplink/to/229547\"},{\"ta_id\":97832,\"partner_id\":\"id34234\",\"partner_url\":\"http://partner.com/deeplink/to/id34234\"}]";
    JavaScriptSerializer j = new JavaScriptSerializer();
    object[] objects = (object[])j.DeserializeObject(s);
    string[] ids = objects.Cast<Dictionary<string, object>>()
                          .Select(dict => (string)dict["partner_id"])
                          .ToArray();
    
