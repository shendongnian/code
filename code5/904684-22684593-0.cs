        string SourceFolderPath = System.IO.Path.Combine(FolderPath, "Initial");
        Response.Clear();
        Response.ContentType = "application/zip";
        Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", nameFolder + ".zip"));
       
        bool recurseDirectories = true;
        using (ZipFile zip = new ZipFile())
        {
            zip.AddSelectedFiles("*", SourceFolderPath, string.Empty, recurseDirectories);
            zip.Save(Response.OutputStream);
        }
        Response.End();
