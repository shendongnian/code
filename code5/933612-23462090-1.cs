    public List<string> Read ( String csvFilePath )
    {
       var list = new List<string>();
       
       using (var stream = new FileStream( csvFilePath, FileMode.Open))
       {
          var reader = new StreamReader( stream);
          stream.Seek(0, SeekOrigin.Begin); 
           list.AddRange(reader.ReadToEnd().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList());
        }
    
       return list;
    }
