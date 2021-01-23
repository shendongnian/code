    void Main()
    {
      XElement root = XElement.Parse (
      @"<?xml version=""1.0"" encoding=""UTF-8""?>
    <session  name=""test"" start=""2014-04-04T15:54:09.728Z"">
      <upload>
        <filename value=""D:\ftp\test1.TXT"" />
        <destination value=""/in/test1.TXT"" />
        <result success=""true"" />
      </upload>
      <touch>
        <filename value=""/in/test2.TXT"" />
        <modification value=""2014-03-27T12:45:20.000Z"" />
        <result success=""true"" />
      </touch>
    </session>");
    
      var filename  = from el in root.Elements("upload")
                      where el.Descendants("result").First().Attribute("success").Value  == "true"
                      select el.Descendants("filename").First().Attribute("value").Value;
                            
            
      Console.WriteLine(filename);
                    
    }
