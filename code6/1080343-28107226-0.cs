    string Idd = Convert.ToString(Page.Request.QueryString["Id"]);
        string DocName = Convert.ToString(Page.Request.QueryString["Name"]);
        #region
        try
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite osite = new SPSite(SPContext.Current.Web.Url))
                    {
                        using (SPWeb web = osite.OpenWeb())
                        {
                            //LinkButton lnkView = (LinkButton)e.CommandSource;
                            //string Name = lnkView.CommandArgument;
                            //string ID = lnkView.ID;
                            SPDocumentLibrary library = web.Lists["Shared Documents"] as SPDocumentLibrary;
                            string filepath = library.RootFolder.Url;
                            string filename = DocName;
                            string IDofDoc = Idd;
    
                            //SPFile file = web.GetFile(library.RootFolder.Url + "/No Easy Day.pdf");
                            SPFile file = web.GetFile(filepath + "/" + filename);
    
                            Stream stream = file.OpenBinaryStream();
    
                            filename= Path.Combine(filepath, filename);
    
                            FileStream fileStream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
                            //string filepath1 = fileStream.Name.Replace(fileStream.Name, @"~\\SAIDI\\" + "Asset//");
                            #region
                            //string filepath1 = (sender as Button).Command;
                            //Response.ContentType = ContentType;
                            //filepath1=MapPath(@"~\\SAIDI\\" +"Asset//"+filepath);
                            //Response.AppendHeader("Content-Disposition", "attachment;filename=" + Path.GetFullPath());
                            //Response.WriteFile(filepath1);
                            //Response.End();                         
                            //duplicate
                            #endregion
                            int buffer = 4096;
                            int read = buffer;
                            byte[] bytes = new byte[buffer];
                            while (read == buffer)
                            {
                                read = stream.Read(bytes, 0, buffer);
                                fileStream.Write(bytes, 0, read);
                                if (read < buffer) break;
                            }
                            stream.Dispose();
                            fileStream.Dispose();
                        }
                    }
                });
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + "<br>" + ex.StackTrace);
        }
