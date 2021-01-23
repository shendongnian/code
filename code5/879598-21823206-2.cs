    string filename = "yourfilename";
    if (filename != "")
    {
        string path = Server.MapPath(filename);
        System.IO.FileInfo file = new System.IO.FileInfo(path);
        if (file.Exists)
        {
             Response.Clear();
             //Content-Disposition will tell the browser how to treat the file.(e.g. in case of jpg file, Either to display the file in browser or download it)
             //Here the attachement is important. which is telling the browser to output as an attachment and the name that is to be displayed on the download dialog
             Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
             //Telling length of the content..
             Response.AddHeader("Content-Length", file.Length.ToString());
             
             //Type of the file, whether it is exe, pdf, jpeg etc etc
             Response.ContentType = "application/octet-stream";
             
             //Writing the content of the file in response to send back to client..
             Response.WriteFile(file.FullName);
             Response.End();
        }
        else
        {
             Response.Write("This file does not exist.");
        }
    }
