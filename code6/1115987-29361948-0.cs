    string FilenameMP3 = "~/someFolder/xyz.mp3";
    string headerFilename = Filename.Substring(Filename.IndexOf("/") + 1);
    Response.AppendHeader("Content-Disposition", String.Concat("attachment;filename=\"", headerFilename, "\""));
    Response.ContentType = "audio/mpeg";
    try
    {
        Response.WriteFile(Filename, true);
        Response.End();
    }
    finally
    {
         Response.StatusCode = 200;
         Response.Close();
    }
