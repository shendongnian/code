    [WebMethod]
            public static string buttonclickImage(string pageNo)
            {
                var name = (name)HttpContext.Current.Session["Projectname"];
                var projectname = name.ProjectName;
                var batchname = name.BatchName;
                var imagename = name.ImageName;
                string concatenatedStr = "/" + projectname + "/" + batchname + "/Input/" + imagename;
    
                int iPageNo = 0;
                if (pageNo != string.Empty && pageNo != "undefined")
                    iPageNo = Int32.Parse(pageNo);
    
                FileTransfer.FileTransferClient fileTranz = new FileTransfer.FileTransferClient();
                FileDto file = fileTranz.GetTifftoJPEG(concatenatedStr, iPageNo, "gmasdll");
    
    
                var fileData = Convert.ToBase64String(file.Content);
    
                return fileData;
            }
