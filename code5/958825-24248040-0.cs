    public class Site
    {  
       public void Update(string url)
       {
       	   var isLoggedIn = Browser.ValidateLogin();
    	   if (!isLoggedIn)
    	   {
    	   	  this.Login();
    	   }
    	   Browser.GetUrl(url);
       }
    }
