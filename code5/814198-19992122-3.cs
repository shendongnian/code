      static void Main(string[] args)
      {
        XmlDocument xml = new XmlDocument();
        xml.Load(@"C:\MR.xml");
        XmlNodeList stations = xml.SelectNodes("//FileDump/Message/Attachment");
        var Message_ID = xml.GetInnerXml("//FileDump/Message/MsgID");
        Console.WriteLine("Message ID is :{0}", Message_ID);
        foreach (XmlNode station in stations)
        {
          var File_Name = station.GetInnerXml("FileName");
          var File_ID = station.GetInnerXml("FileID");
        }
      }
