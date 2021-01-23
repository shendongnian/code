Make sure your Service class inherits from: System.Net.HttpWebRequest
This has properties that you are looking for.
    using System;
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
    using System.Web.Services;
    using System.Web.UI;
    
    namespace WebApplication4
    {
        public partial class WebForm1 : Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                MyService math = new MyService()
                {
                    Credentials = new NetworkCredential("Joe", "mydomain", "password"),
                    AllowAutoRedirect = false,
                    ClientCertificates = new X509CertificateCollection(),
                    ConnectionGroupName = ""
                };
            }
        }
    
        [WebService(Namespace = "http://tempuri.org/")]
        public class MyService : HttpWebRequest
        {
            [WebMethod]
            public int SumOfNums(int First, int Second)
            {
                return First + Second;
            }
        }
    }
**PLEASE MARK THIS AS ANSWER IF THIS SOLVES YOUR PROBLEM.**
Reference: [MSDN][1]
  [1]: http://msdn.microsoft.com/en-us/library/System.Net.HttpWebRequest_properties(v=vs.110).aspx
