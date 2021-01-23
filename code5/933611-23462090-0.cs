    public List<string> Read ( String csvFilePath )
    {
       var list = new List<string>();
       
       using (var stream = new FileStream( csvFilePath))
       {
          var reader = new StreamReader( stream);
          stream.Seek(0, SeekOrigin.Begin); 
           list.AddRange(sw.ReadToEnd().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList());
        }
    
       return list;
    }
