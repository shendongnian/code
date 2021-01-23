    using Newtonsoft.Json.Linq;
    using System.Web;
    private static frmBrowser browser = null;
    private const string BoxClientId = "{your client id}";
    private const string BoxSecret = "{your secret}";    
    private void authenticateWithBox()
    {
       browser = new frmBrowser();
       browser.Show();
       browser.webControl1.Source = new Uri("https://www.box.com/api/oauth2/authorize?response_type=code&client_id=" + BoxClientId + "&redirect_uri=https://localsess");
       browser.webControl1.AddressChanged += new Awesomium.Core.UrlEventHandler(webControl1_AddressChanged);
    }
    void webControl1_AddressChanged_Box(object sender, Awesomium.Core.UrlEventArgs e)
    {
      //MessageBox.Show(e.Url.ToString());
      if (e.Url.Host == "localsess")
      {
        NameValueCollection parms = HttpUtility.ParseQueryString(e.Url.Query);
        if (parms.AllKeys.Contains("error"))
        {
           MessageBox.Show("Error connecting to Box.com: " + parms["error"] + " " + parms["error_description"]);
        }
        else
        {
            boxContinue(parms["code"]);
        }
      }
    }
