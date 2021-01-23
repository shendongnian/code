    public string ConvertDataTableToXml(DataTable table)
     {
      MemoryStream stream = new MemoryStream();
      table.WriteXml(stream, true);
      str.Seek(0, SeekOrigin.Begin);
      StreamReader reader = new StreamReader(stream);
      string xmlstr;
      xmlstr = reader.ReadToEnd();
      return (xmlstr);
     }
