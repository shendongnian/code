    public class LoginRequest : BaseRequest
    {
        public string username { get; set; }
        public string password { get; set; }
        public otherclass d { get; set; }
        public String getQueryString(){
          return "username="+this.username+"&password="+this.password+"&a="+this.d.a+"&b="+this.d.b;
        }
    }
    
    public class otherclass
    {
        public string a { get; set; }
        public string b { get; set; }
    }
