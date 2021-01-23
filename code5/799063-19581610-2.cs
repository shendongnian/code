        User ObjUs = new User();
        ObjUs.UserLoginName = "steve";
        ObjUs.UserID = -2147483637;
        ObjUs.IsDeleted = false;
         System.Web.Script.Serialization.JavaScriptSerializer ObjSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
      object sSeralize = ObjSerializer.Serialize(ObjUs);
       HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:54002/api/user/AddUser HTTP/1.1");
       byte[] data = Encoding.UTF8.GetBytes(sSeralize.ToString()); // Input Data
       request.Method = "POST";
       request.Accept = "application/json";
       request.ContentType = "application/json";
       Stream dataStream = request.GetRequestStream();
       dataStream.Write(data, 0, data.Length);
       dataStream.Close();
       HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
       StreamReader result = new StreamReader(resp.GetResponseStream());
       if(result !=null)
       {      
       if(!string.IsnullorEmpty(result.ReadToEnd()))
       {
        String sResponseData = result.ReadToEnd(); 
       }
       }
    public class User
    {
    public String UserLoginName { get; set; }
    public int UserID { get; set; }
    public bool IsDeleted { get; set; }
     }  
  
