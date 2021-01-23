Make sure your Service class inherits from: System.Net.HttpWebRequest
This has properties that you are looking for like ConnectionGroupName, Container etc
    public class Service1 : System.Net.HttpWebRequest
    {   
    }
e.g
    void Btn_Click(Object Src, EventArgs E)
    {
        MyService math = new MyService();
        ICredentials credentials = new NetworkCredential("Joe", "mydomain", "password");
        math.Credentials = credentials;
        math.AllowAutoRedirect = false;
        math.ClientCertificates = new System.Security.Cryptography.X509Certificates.X509CertificateCollection();
        math.ConnectionGroupName = "";
    }
    
    [System.Web.Services.WebService(Namespace = "http://tempuri.org/")]
        public class MyService : System.Net.HttpWebRequest
        {
            [System.Web.Services.WebMethod]
            public int SumOfNums(int First, int Second)
            {
                return First + Second;
            }
        }
Reference: [MSDN][1]
  [1]: http://msdn.microsoft.com/en-us/library/System.Net.HttpWebRequest_properties(v=vs.110).aspx
