	using System;
	using System.Collections.Specialized;
	using System.Security.Cryptography;
	using System.Text;
	using System.Net;
	static void Main()
	{
	    // see: http://api-wiki.apps.rackspace.com/api-wiki/index.php/Main_Page
	    var apiKey = "";
	    var secretKey = "";
	    var wm = new WebMethods(new System.Net.WebClient(), "https://api.emailsrvr.com/v0/", apiKey, secretKey);
	    Console.Write(wm.Get("domains")); // Get list of Domains
	    Console.Write(wm.Get("domains/example.com")); // Get summary of services in Domain
	    Console.Write(wm.Get("domains/example.com/ex/mailboxes")); // Get Rackpsace Email Mailboxes for Domain
	    Console.Write(wm.Get("domains/example.com/rs/mailboxes")); // Get Microsoft Exchange Mailboxes for Domain
	}
	public class WebMethods
	{
	    private WebClient client;
	    private string baseUrl;
	    private string apiKey;
	    private string secretKey;
	    private string format;
	    public WebMethods(WebClient client, string baseUrl, string apiKey, string secretKey, string format = "text/xml")
	    {
	        this.client = client;
	        this.baseUrl = baseUrl;
	        this.apiKey = apiKey;
	        this.secretKey = secretKey;
	        this.format = format;
	    }
	    public virtual string Get(string url)
	    {
	        return MakeRemoteCall((client) =>
	        {
	            return client.DownloadString(baseUrl + url);
	        },
	        format);
	    }
	    public virtual string Post(string url, System.Collections.Specialized.NameValueCollection data)
	    {
	        return MakeRemoteCall((client) =>
	        {
	            var bytes = client.UploadValues(baseUrl + url, data);
	            return Encoding.UTF8.GetString(bytes);
	        },
	        format);
	    }
	    private void SignMessage()
	    {
	        var userAgent = "C# Client Library";
	        client.Headers["User-Agent"] = userAgent;
	        var dateTime = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
	        var dataToSign = apiKey + userAgent + dateTime + secretKey;
	        var hash = System.Security.Cryptography.SHA1.Create();
	        var signedBytes = hash.ComputeHash(Encoding.UTF8.GetBytes(dataToSign));
	        var signature = Convert.ToBase64String(signedBytes);
	        client.Headers["X-Api-Signature"] = apiKey + ":" + dateTime + ":" + signature;
	    }
	    private void AssignFormat(string format)
	    {
	        client.Headers["Accept"] = format;
	    }
	    private string MakeRemoteCall(Func remoteCall, string format)
	    {
	        SignMessage();
	        AssignFormat(format);
	        return remoteCall.Invoke(client);
	    }
	}
