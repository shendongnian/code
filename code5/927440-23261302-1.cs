    public class MyHandler : IHttpHandler {
    public void ProcessRequest (HttpContext context) {
        CreateUser();
    }
    public bool IsReusable {
        get {
            return false;
        }
    }
    private Employee CreateUser()
    {
        
    }
