    Response.ContentType = "Application/pdf";
    
    Response.AppendHeader("Content-Disposition", "attachment; filename=File_Name.pdf");
    
    Response.TransmitFile(Server.MapPath("Folder_Name/File_Name.pdf"));
    
    Response.End();
