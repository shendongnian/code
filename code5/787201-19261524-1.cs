     public class HttpContextWrapper :IHttpContextWrapper
     {
	     publlic void Reditect(string url)
	     {
                Response.Redirect(url, true);		
	     }
     } 
