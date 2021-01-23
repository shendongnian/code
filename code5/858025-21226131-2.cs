      public void ProcessRequest (HttpContext context) 
        { 
              int ID;
              if (context.Request.QueryString["ID"] != null)
                   ID= Convert.ToInt32(context.Request.QueryString["ID"]);
              else
                throw new ArgumentException("No parameter specified");
    
            byte[] imageData= ;//get the image data from the database using the employeeId Querystring
            Response.ContentType = "image/jpeg";
            Response.BinaryWrite(imageData);
    
        } 
