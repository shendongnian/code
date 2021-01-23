    StreamReader reader = new StreamReader( file_name );
    var resp = HttpContext.Current.Response;
    
    
    // Verify that the client is connected.
    
    if (resp.IsClientConnected)
    {
        resp.Clear();
        resp.ClearHeaders();
        //Indicate the type of data being sent
        resp.ContentType = "application/zip";
        resp.AppendHeader( "Content-Disposition", "attachment; filename=\"" + Path.GetFileName( file_name ) + "\"" );
        resp.AppendHeader( "Content-Length", reader.BaseStream.Length.ToString() );
        resp.TransmitFile( file_name ); //does not buffer into memory, therefore scales better for large files and heavy usage
        resp.End();
    }
