          void Application_BeginRequest(object sender, EventArgs e)
        
        {
                    
                    string para2;
        
                    string para1;
        
                    string CurrentPath = Request.Path.ToLower();
        
                if (CurrentPath.Contains("http://servername/directory"))
                {
            
                    //Get the two parameters from the url, here i am assuming that directory is static 
                    //If not then you can change below two line for getting the passed parameters from url.
                    //I think it is easy task just use some string functions         
                    para2 = CurrentPath.Substring(CurrentPath.LastIndexOf("/"));
                    para1 = CurrentPath.Substring(CurrentPath.IndexOf("directory"), CurrentPath.LastIndexOf("/"));      
                    //Now work on these parameters and calculate the redirect page.
                
                    //Replcing the httpcontext with new page
                    HttpContext MyContext = HttpContext.Current;
                    MyContext.RewritePath("path of your new page according calculations");
                }
            }
    
     
    
    > In this method the application beginRequest will be called for every request.And you work on the current url.
