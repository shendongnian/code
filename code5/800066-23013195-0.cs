    public class WebApp : BrowserWindow
    {
       private string _url;
    
       public WebApp(string url)
       {
          //define search properties using this keyword so the web application can be treated as a browser
          _url = url;
          BrowserWindow.CurrentBrowser = "Chrome";
          this.CopyFrom(BrowserWindow.Launch(new Uri(url));
       }
    }
