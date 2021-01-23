    private void readZipFile(String filePath)
        {
            String fileContents = "";
            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.Compression.ZipArchive apcZipFile = System.IO.Compression.ZipFile.Open(filePath, System.IO.Compression.ZipArchiveMode.Read);
                    foreach (System.IO.Compression.ZipArchiveEntry entry in apcZipFile.Entries)
	                {
		                    if (entry.Name.ToUpper().EndsWith(".XML"))
	                        {
                                System.IO.Compression.ZipArchiveEntry zipEntry = apcZipFile.GetEntry(entry.Name);
                                using (System.IO.StreamReader sr = new System.IO.StreamReader(zipEntry.Open()))
                                {
                                    //read the contents into a string
                                    fileContents = sr.ReadToEnd();
                                }
	                        }
	                }
                   
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
