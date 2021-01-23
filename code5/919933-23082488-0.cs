    public void ExtractLibraryZipFolder(SPWeb web, SPList myList, string FolderPath, SPFile myFile, bool overWrite)
        {
            ZipArchive myZip = new ZipArchive(myFile.OpenBinaryStream());
            foreach (ZipArchiveEntry subZip in myZip.Entries)
            {
                MemoryStream myMemoryStream = new MemoryStream();
                subZip.Open().CopyTo(myMemoryStream);
                if (FolderPath != string.Empty)
                {
                    SPFolder theFolder = web.GetFolder("/ImportToolLibrary/");
                    theFolder.SubFolders[FolderPath].Files.Add(subZip.Name, myMemoryStream);
                }
                else
                {
                    SPFile myUpload = myList.RootFolder.Files.Add(subZip.Name, myMemoryStream);
                }                
            }
        }
