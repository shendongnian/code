    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        string name = context.Request.Form["contactname"];
        string email = context.Request.Form["contactemail"];
        string content = context.Request.Form["contactmessage"];
        try
        {
            SendEmail(name, email, content);
        }
        catch (Exception ex)
        {
           // Write exception message to user
           // You can include some of the exception detail via the ex object, 
           // but be careful how much information you divulge to the user 
           context.Response.Write("There was a problem sending the email.");
        }
        // Email was sent successfully
        context.Response.Write("Email sent successfully.");
    }
