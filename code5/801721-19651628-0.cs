        string file = "";
        file = context.Request.QueryString["file"]; 
        if (file != "")
        {
            context.Response.Clear(); 
            context.Response.ContentType = "application/octet-stream";
            context.Response.AddHeader("content-disposition", "attachment;filename="    +           Path.GetFileName(file));
            context.Response.WriteFile(file);
            context.Response.End();
        }
