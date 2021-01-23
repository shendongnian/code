    public static Dictionary<string, byte[]> Decompress(Stream targFileStream)
    {
        Dictionary<string, byte[]> files = new Dictionary<string, byte[]>();
    
        using(ZipFile z = ZipFile.Read(targFileStream))
        {
            foreach (ZipEntry zEntry in z)
            {
                MemoryStream tempS = new MemoryStream();
                zEntry.Extract(tempS);
    
                files.Add(zEntry.FileName, tempS.ToArray());
            }
        }
    
        return files;
    }
