    foreach (string filePath in Directory.GetFiles(ZippedFilesDestinationFolder))
    {
        try
        {
            using (ZipFile zip1 = ZipFile.Read(filePath))
            {
                foreach (ZipEntry e in zip1)
                {
                    e.Extract(unpackdirectory, ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }
        catch(Exception ex) { /* Log ex here */ }
    }
