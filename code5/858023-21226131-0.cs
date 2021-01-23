      public void ProcessRequest (HttpContext context) 
        { 
              int ID;
              if (context.Request.QueryString["ID"] != null)
                   ID= Convert.ToInt32(context.Request.QueryString["ID"]);
              else
                throw new ArgumentException("No parameter specified");
    
            byte[] imageData= ;
            Response.ContentType = "image/jpeg";
            Response.BinaryWrite(imageData);
    
        } 
