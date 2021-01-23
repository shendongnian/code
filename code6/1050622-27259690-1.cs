        public static void ZipFile(string path)
        {
            var data = new MemoryStream(File.ReadAllBytes(path));
            var zip = new ZipArchive(data, ZipArchiveMode.Create,false);
            zip.CreateEntry(path + ".zip");            
        }
    
