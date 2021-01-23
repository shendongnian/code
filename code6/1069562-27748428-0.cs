    if (FileUpload1.HasFile)
    {
    System.IO.FileInfo file = new System.IO.FileInfo(FileUpload1.PostedFile.FileName);
    string fname = file.Name.Remove((file.Name.Length - file.Extension.Length));
    fname = fname + Guid.NewGuid().ToString("N") + file.Extension;
    string photo = "";
    photo = fname;
        
    FileUpload1.SaveAs(Server.MapPath("~/images/dp/" + fname));
    Image1.ImageUrl = "~/images/dp/" + fname;
    }
    else
    {
        //  saved.InnerText = "Please Select Employee Photo";
    }
