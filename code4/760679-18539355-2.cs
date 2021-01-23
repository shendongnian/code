    private static string SaveSharedFile(int userAlertId, HttpPostedFileBase file)
        {
            string fileName = null;
            fileName = System.IO.Path.GetFileName(file.FileName);
            if (fileName != "")
            { 
                const int BufferSize = 65536; // 65536 = 64 Kilobytes
                string Filepath = userAlertId.ToString();  
                using (FileStream fs = System.IO.File.Create(Filepath))
                {
                    using (Stream reader = System.Web.HttpContext.Current.Request.GetBufferlessInputStream())
                    {
                        byte[] buffer = new byte[BufferSize];
                        int read = -1, pos = 0;
                        do
                        {
                            int len = (file.ContentLength < pos + BufferSize ?
                                file.ContentLength - pos :
                                BufferSize);
                            read = reader.Read(buffer, 0, len);
                            fs.Write(buffer, 0, len);
                            pos += read;
                        } while (read > 0);
                    }
                }
            }
            return fileName;
        }
