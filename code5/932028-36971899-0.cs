    public void ExtractZipFileToPath(
            string zipFilePath,
            string ouputPath
            )
        {
            using (var zip = ZipFile.Read(zipFilePath))
            {
                foreach (var entry in zip.Entries.ToList())
                {
                    entry.FileName = SanitizeFileName(entry.FileName);
                    entry.Extract(ouputPath);
                }
            }
        } 
