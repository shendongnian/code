    protected void DescargarArchivo(string strRuta, string strFile)
    {
        FileInfo ObjArchivo = new System.IO.FileInfo(strRuta);
        Response.Clear();
        Response.AddHeader("Content-Disposition", "attachment; filename=" + strFile);
        Response.AddHeader("Content-Length", ObjArchivo.Length.ToString());
        Response.ContentType = "application/pdf";
        Response.WriteFile(ObjArchivo.FullName);
        Response.End();
        
    }
