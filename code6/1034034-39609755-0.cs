        string fileName = "";
        Response.ContentType = "application/vnd.ms-excel";
        fileName = Server.MapPath("~/WriteReadData/Excelfiles/Excelfile.xls");  
       //Give path name\file name.
        Response.AppendHeader("Content-Disposition", "attachment; filename="Excelfile.xls");
        //Specify the file name which needs to be displayed while prompting
        Response.TransmitFile(fileName);
        Response.End();
