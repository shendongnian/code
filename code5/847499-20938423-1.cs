    string filePath = "~/Content/Exports/Temp/";
    
    string WordTemplateFile = HttpContext.Current.Server.MapPath("/Content/Templates/WordTemplate.docx");
    string DestinationPath = HttpContext.Current.Server.MapPath(filePath);
    string NewFileName = DOCXFileName + ".docx";
    
    string destFile = System.IO.Path.Combine(DestinationPath, NewFileName);
    
    System.IO.File.Copy(WordTemplateFile, destFile, true);
    
    SaveDOCX(destFile, HTMLString, isLandScape, rMargin, lMargin, bMargin, tMargin);
