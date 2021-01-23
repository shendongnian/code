        [WebMethod]
        public string GetSoundFile(string pSoundFolder)
            {
                string[] pFiles = Directory.GetFiles(pSoundFolder, "*.wav", SearchOption.AllDirectories);
        
                string pFileList = "";
                for (int ii = 0; ii < pFiles.Length; ii++)
                {
                    pFileList += "|" + pFiles[ii];                      
                }
        
                return (pFileList);
            }
