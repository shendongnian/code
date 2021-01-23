    private void DownloadFile( string fname, bool forceDownload )
    {
      string path = MapPath( fname );
      string name = Path.GetFileName( path );
      string ext = Path.GetExtension( path );
      string type = "";
      // set known types based on file extension  
      if ( ext != null )
      {
        switch( ext.ToLower() )
        {
        case ".htm":
        case ".html":
          type = "text/HTML";
          break;
      
        case ".txt":
          type = "text/plain";
          break;
         
        case ".doc":
        case ".rtf":
          type = "Application/msword";
          break;
        }
      }
      if ( forceDownload )
      {
        Response.AppendHeader( "content-disposition",
            "attachment; filename=" + name );
      }
      if ( type != "" )   
        Response.ContentType = type;
      Response.WriteFile( path );
      Response.End();    
    }
