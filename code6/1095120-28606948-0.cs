     public string GetSoundFile()
        {
            string WorkingDirectory = HttpContext.Current.Server.MapPath("~/sounds");                    
            
            string[] pFiles = Directory.GetFiles(WorkingDirectory);
            
            string pFileList = "";
            
            for (int ii = 0; ii < pFiles.Length; ii++)
            {
                if (pFileList == "")
                {
                    pFileList = pFiles[ii];
                }
                else
                {
                    pFileList += "|" + pFiles[ii];
                }
            }
    
            return (pFileList);
        }
