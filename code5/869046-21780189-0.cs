    public class AuthResponse {
        public bool LoginResult { get; set; }
    }
    
    System.Web.Script.Serialization.JavaScriptSerializer sr = new System.Web.Script.Serialization.JavaScriptSerializer();
    
    AuthResponse response = sr.Deserialize<AuthResponse>(responseText);
