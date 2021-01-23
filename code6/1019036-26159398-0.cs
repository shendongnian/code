    protected void DownloadFile(string fileName)        {
                
                    fileName = hdnFileNameDms.Value;
                    string practiceCode = Profile.PracticeCode;
                    // string filepath = HttpContext.Current.Server.MapPath(@"~/WEBEHR/DMS/Documents/" + practiceCode + "/" + fileName);
                    string filepath = hdnFilePath.Value;
                    FileInfo fileinfo = new FileInfo(filepath);
    
                    string webfile = String.Empty;
                    string[] stringSeparators = new string[] { "WEBEHR", "webehr" };
                    string[] fileurl = filepath.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                    var url = HttpContext.Current.Request.Url.ToString();
                    string[] weburls = url.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                    if (fileurl.Length > 1 && weburls.Length > 1)
                    {
                        webfile = weburls[0] + "webehr" + fileurl[1];
                    }
    
    
                    if (Request.UserAgent.ToLower().Contains("iphone") || Request.UserAgent.ToLower().Contains("ipad") || Request.UserAgent.ToLower().Contains("mobile"))
                    {
                        IpadResponseHelperDMS.Redirect(webfile, "_blank", "menubar=0,width=100,height=100");
                        return;
                    }
                    Response.ContentType = ReturnExtension(fileinfo.Extension.ToLower());
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName.Replace(",", ""));
                    Response.AddHeader("Content-Length", fileinfo.Length.ToString());
                    Response.BinaryWrite(File.ReadAllBytes(filepath));
                    Response.End();
                }
