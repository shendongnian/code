    if (FileUpload1.HasFile)
    {
        string extension = System.IO.Path.GetExtension(FileUpload1.FileName);
    
        if (extension == ".jpg")
        {
            FileUpload1.SaveAs("yourpath" + FileUpload1.FileName);
    
        }
        else
        {
        Response.Write("Only .Jpg allowed");
        }
    }  
