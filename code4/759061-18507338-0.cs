    var output = new MemoryStream();
    using (var gzip = new GZipOutputStream(output))
    using (var tar = TarArchive.CreateOutputTarArchive(gzip))
                {
                    for (int i = 0; i < files.Count; i++)
                    {                    
                        var tarEntry = TarEntry.CreateEntryFromFile(file);                    
                        tar.WriteEntry(tarEntry,false);
                    }
    
                    tar.IsStreamOwner = false;
                    gzip.IsStreamOwner = false;
                }
    
                
