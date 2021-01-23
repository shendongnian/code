    public Task<bool> PsiZipFilesAsync(string zipFileName_, string[] listOfFiles_)
        {
    
            return Task.Run(() => 
            {
                using (ZipArchive zip = new ZipArchive())
                {
                    //zip.Password = pass;
                    zip.EncryptionType = EncryptionType.PkZip;
                    zip.AddFiles(listOfFiles_);
    
                    zip.Save(zipFileName_);
    
                }
                return true;
            });
    
        }
