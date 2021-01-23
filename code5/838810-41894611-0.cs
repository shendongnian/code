    I'm Using this code and it's working fine..... C# code ASP.NET
    
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Script.Serialization;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    namespace LI
    {
    public partial class WebForm3 : System.Web.UI.Page
    {
       
        public string redirectUrl = "http://localhost:64576/WebForm3";
        public string TokenGlobe = ""; 
        public String apiKey = "API_KEY";
        public string retval = "";
        public String apiSecret = "API_Secret";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["code"] != null)
                {
                    VerifyAuthentication(Request.QueryString["code"]);
                }
            }
        }
        protected void btnTwit_Click(object sender, EventArgs e)
        {
            var Address = "https://www.linkedin.com/oauth/v2/authorization?response_type=code&client_id=" + apiKey + "&redirect_uri=http://localhost:64576/WebForm3&state=987654321&scope=w_share";
            
            using (var webClient = new WebClient())
            {
                webClient.Headers.Add("x-li-format", "json");
                
            }
            Response.Redirect(Address);
        }
        public String VerifyAuthentication(string code)
        {
            string authUrl = "https://www.linkedin.com/oauth/v2/accessToken";
            var sign1 = "grant_type=authorization_code&code=" + code + "&redirect_uri=" + redirectUrl + "&client_id=" + apiKey + "&client_secret=" + apiSecret + "";
            var sign = "grant_type=authorization_code&code=" + HttpUtility.UrlEncode(code) + "&redirect_uri=" + HttpUtility.HtmlEncode(redirectUrl) + "&client_id=" + apiKey + "&client_secret=" + apiSecret;
            
            HttpWebRequest webRequest = System.Net.WebRequest.Create(authUrl + "?" + sign) as HttpWebRequest;
            webRequest.Method = "POST";
            webRequest.Host = "www.linkedin.com";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            Stream dataStream = webRequest.GetRequestStream();
            String postData = String.Empty;
            byte[] postArray = Encoding.ASCII.GetBytes(postData);
            dataStream.Write(postArray, 0, postArray.Length);
            dataStream.Close();
            WebResponse response = webRequest.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader responseReader = new StreamReader(dataStream);
            String returnVal = responseReader.ReadToEnd().ToString();
            responseReader.Close();
            dataStream.Close();
            response.Close();
            var stri = redirectUrl;
            retval = returnVal.ToString();
            var objects = JsonConvert.DeserializeObject<Accountdsdsd>(retval);//JArray.Parse(retval);
            TokenGlobe = objects.access_token;
            var SentStatus = PostLinkedInNetworkUpdate(TokenGlobe, "Hello API"); //Share
           
            return TokenGlobe;
            // return responseReader.ReadToEnd().ToString();
        }
    
        private string linkedinSharesEndPoint = "https://api.linkedin.com//v1/people/~/shares?oauth2_access_token={0}&format=json";
        private const string defaultUrl = "http://localhost:64576/WebForm3";
        private const string defaultImageUrl = "http://opusleads.com/opusing/technology/technology%20(1).jpg"; //Image To Post
        public bool PostLinkedInNetworkUpdate(string accessToken, string title, string submittedUrl = defaultUrl, string submittedImageUrl = defaultImageUrl)
        {
            var requestUrl = String.Format(linkedinSharesEndPoint, accessToken);
            var message = new
            {
                comment = "Testing out the LinkedIn Share API with JSON",
                content = new Dictionary<string, string>
        { { "title", title },
            { "submitted-url", submittedUrl },
            {"submitted-image-url" , submittedImageUrl}
        },
                visibility = new
                {
                    code = "anyone"
                }
            };
            var requestJson = new JavaScriptSerializer().Serialize(message);
            var client = new WebClient();
            var requestHeaders = new NameValueCollection
    {
       
        {"Content-Type", "application/json" },
                {"x-li-format", "json" }
               
    };
            client.Headers.Add(requestHeaders);
            var responseJson = client.UploadString(requestUrl, "POST", requestJson);
            var response = new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(responseJson);
            return response.ContainsKey("updateKey");
        }
    }
    
    //Json Parsing
    public class Accountdsdsd
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
    }
}`
