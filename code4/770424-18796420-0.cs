    using (var stream = new StreamReader( File.Open(_file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
         {
             string str = stream.ReadToEnd();
             int x = str.LastIndexOf('\n');
             string lastline = str.Substring(x + 1);                              
         }
