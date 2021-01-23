    if (context.Request.Path == ConfigPath)
    {
        StringBuilder sb = new StringBuilder();
                    
        sb.Append("<html><head></head><body><form action=\"apply_config\" method=\"post\">");
        sb.Append("<input type=\"submit\" value=\"Log Selected Parameters\">");
        sb.Append("<input type=\"text\" value=\"helloworld\" name=\"test\"></input>");
        sb.Append("</body>");
        sb.Append("</html>");
        return context.Response.WriteAsync(sb.ToString());
    }
    else if (context.Request.Path == ConfigApplyPath)
    {
        /* I want to access and parse the POST data here */
        /* Tried looking into context.Request.Body as a MemoryStream, 
            but not getting any data in it. */
        StringBuilder sb = new StringBuilder();
        byte[] buffer = new byte[8000];
        int read = 0;
                    
        read = context.Request.Body.Read(buffer, 0, buffer.Length);
        while (read > 0)
        {
            sb.Append(Encoding.UTF8.GetString(buffer));
            buffer = new byte[8000];
            read = context.Request.Body.Read(buffer, 0, buffer.Length);
        }
                    
        return context.Response.WriteAsync(sb.ToString());
    }
    else 
    {
        return context.Response.WriteAsync(GetSensorInfo());
        /* Returns JSON string with sensor information */
    }
