    private bool FindInDocx(string file,string search)
            {
    
                var ms = new MemoryStream();
                using (ZipFile zip = ZipFile.Read(file))
                {
                    ZipEntry a = zip[@"word\document.xml"];
                    a.Extract(ms);
                }
                ms.Position = 0;
                var sr = new StreamReader(ms);
                var myStr = sr.ReadToEnd();
                
                return myStr.Contains(search);
                
            }
