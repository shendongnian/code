        using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Newtonsoft.Json.Linq;
    using OAuth2;
    namespace WebApplication2
    {
        public partial class SamplePage : System.Web.UI.Page
        {
            public enum Method { GET, POST, PUT, DELETE };
    
            public const String apikey = "YOURAPP_API_KEY";
            public const String Secretkey = "YOUR_APP_SECRETKEY";
            public const String linkedInPeapleURL = "https://api.linkedin.com/v1/people/~";
            public const String generateAuthorizationCode = "https://www.linkedin.com/uas/oauth2/authorization?response_type=code";
            public const String state= "qwertyytrewq123";
            public const String redirectURI = "http://localhost:17681/SamplePage.aspx";
            public const String generateAccessToeknURL = "https://www.linkedin.com/uas/oauth2/accessToken?grant_type=authorization_code";
            public String code="";
            public const String useAccessToeknURL = "https://api.linkedin.com/v1/people/~?oauth2_access_token=";
            public const String scope = "r_basicprofile";// r_fullprofile r_emailaddress r_network r_contactinfo rw_nusrw_groups w_messages"; 
    		// OR SET permission while create Application in linked in
            public String AccessToken;
            
            protected void Page_Load(object sender, EventArgs e)
            {
    
                //Redirect
                string url = getAuthorizationURL();
    
              //  url=HttpUtility.UrlEncode(url);
    
                //WebRequest(Method.GET, url, "");
    
                if (Request.QueryString["code"] == null)
                {
    
                    Response.Redirect(url, true);
                }
                else
                {
                    code = Request.QueryString["code"];
                    String response = WebRequest(Method.GET, getAccessToeknURL(), "");
    
                    JObject jobj = JObject.Parse(response);
    
                    AccessToken = jobj["access_token"].ToString();
    
                    response = WebRequest(Method.GET, linkedInPeapleURL+ "?oauth2_access_token=" + AccessToken, ""); // get basic detail
                   // response = WebRequest(Method.GET, linkedInPeapleURL + "/email-address" + "?oauth2_access_token=" + AccessToken, ""); // get Email id
    
    
    
    
                    //GET Request 
                }
    
    
    
                // POST request
    
    
    
                //GET Request 
    
                
                    
    
    
            }
            public string getAccessToeknURL()
            {
                String url = "";
    
                url = generateAccessToeknURL + "&code=" + code + "&redirect_uri=" + redirectURI + "&client_id=" + apikey + "&client_secret=" + Secretkey;
    
                return url;
            }
            private String getAuthorizationURL()
            {
                String response = generateAuthorizationCode + "&client_id=" + apikey +"&state=" + state + "&redirect_uri=" + redirectURI;
               return response;
            }
    
            public string WebRequest(Method method, string url, string postData)
            {
                HttpWebRequest webRequest = null;
                StreamWriter requestWriter = null;
                string responseData = "";
    
                webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
                webRequest.Method = method.ToString();
                webRequest.ServicePoint.Expect100Continue = false;
                //webRequest.UserAgent  = "Identify your application please.";
                //webRequest.Timeout = 20000;
    
                if (method == Method.POST)
                {
                    webRequest.ContentType = "application/x-www-form-urlencoded";
    
                    //POST the data.
                    requestWriter = new StreamWriter(webRequest.GetRequestStream());
                    try
                    {
                        requestWriter.Write(postData);
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        requestWriter.Close();
                        requestWriter = null;
                    }
                }
                
                //webRequest.ContentType = "text/plain";
                responseData = WebResponseGet(webRequest);
    
                webRequest = null;
    
                return responseData;
    
            }
            public string WebResponseGet(HttpWebRequest webRequest)
            {
                
                StreamReader responseReader = null;
                string responseData = "";
    
                try
                {
                    responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                    responseData = responseReader.ReadToEnd();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    webRequest.GetResponse().GetResponseStream().Close();
                    responseReader.Close();
                    responseReader = null;
                }
    
                return responseData;
            }
    
        }
    }
