    using (SPSite site = new SPSite("site url",SPUserToken.SystemAccount))
    {
                using (SPWeb web = site.OpenWeb())
                {
                    SPFile file = (SPFile)web.GetFileOrFolderObject("file_url");
                    using (Stream srcFile = file.OpenBinaryStream())
                    {
                        using (Stream destFile = System.IO.File.OpenWrite("C:\\filename.extension"))
                        {
                            byte[] buffer = new byte[8 * 1024];
                            int byteReadInLastRead;
                            while ((byteReadInLastRead = srcFile.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                destFile.Write(buffer, 0, byteReadInLastRead);
                            }
                        }
                    }
                }
            }
