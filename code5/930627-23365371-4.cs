    try
            {
                using (SPSite site = new SPSite(SPContext.Current.Web.Url))
                {
                    SPWeb currentWeb = site.RootWeb;
                    currentWeb.ParserEnabled = false;
                    SPFile spFile = currentWeb.GetFile(@"/Shared%20Documents/test.xls"); // ur documet url saved in document library
                    string localFileName = Path.Combine(@"c:\Users\anbuj\Documents\Backup", string.Format("{0}.xls","tempfile")); // tenpFilePath is where u wanna save ur file
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        FileStream outStream = new FileStream(localFileName, FileMode.Create);
                        byte[] fileData = spFile.OpenBinary();
                        outStream.Write(fileData, 0, fileData.Length);
                        outStream.Close();
                    }
                        );
                   
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
