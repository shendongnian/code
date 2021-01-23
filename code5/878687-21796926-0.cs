    protected void File_Upload(object sender, AjaxFileUploadEventArgs e)
    {   
        List<String> pathlist =  new List<String>();
        if (Session["UploadedPath"] != null)
        {
           pathlist = (List<String>)Session["UploadedPath"];
        }
    
        string filename = e.FileName;
        string path = "~/Documents/" + filename;
        this.AjaxFileUpload1.SaveAs(Server.MapPath(path));
        pathlist.Add(path);
        Session["UploadedPath"] = pathlist;
    }
