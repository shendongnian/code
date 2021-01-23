    <%@ WebHandler Language="C#" Class="Handler" %>
    using System;
    using System.IO;
    using System.Web;
    using Deimand.Business;
    using System.Configuration;
    
    public class Handler : IHttpHandler
    {
        public bool IsReusable
        { get{ return false; } }
    	
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/jpeg";
            if (context.Request.QueryString["imageId"] != null)
            {
               byte[] imageContent = File.ReadAllBytes("C:\yourimage.jpg")
       		   context.Response.OutputStream.Write(imageContent, 0, imageContent.Length);
            }
        }
    }
