    string Url = "FullPatchYourFile";
    FileInfo file = new FileInfo(Url);
    try
    {
        Response.Clear();
        Response.ClearHeaders();
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment;filename=YourFileName");
        Response.AddHeader("Content-Type", "application/zip"); 
        Response.ContentType = ".zip"; //YourExtensionFile
        Response.AddHeader("Content-Length", file.Length.ToString());
        Response.WriteFile(file.FullName);
        Response.TransmitFile(file.FullName);
        Response.End();
    }
    finally
    {
        Your instructions after response.end();
    }
