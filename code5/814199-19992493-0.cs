    static void Main(string[] args)
    {
        XmlDocument xml = new XmlDocument();
        xml.Load(@"C:\MR.xml");
        XmlNodeList stations = xml.SelectNodes("//FileDump/Message/Attachment");
        var Message_ID = xml.SelectSingleNode("//FileDump/Message/MsgID").InnerXml;
    
        Console.WriteLine("Message ID is :{0}", Message_ID);
    
        foreach (XmlNode station in stations)
        {
            var fileNameNode = station.SelectSingleNode("FileName");
            var fileIdNode = station.SelectSingleNode("FileID");
            
            var File_Name = fileNameNode == null ? (string)null : fileNameNode.InnerXml;
            
            var File_ID = fileIdNode == null ? (string)null : fileIdNode.InnerXml;;
        }
    }
