    class example
    {
        static void Main(string[] args)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(@"C:\MR.xml");
            XmlNodeList stations = xml.SelectNodes("//FileDump/Message/Attachment");
            var Message_ID = xml.SelectSingleNode("//FileDump/Message/MsgID").InnerXml;
    
            Console.WriteLine("Message ID is :{0}", Message_ID);
    
            foreach (XmlNode station in stations)
            {
                string File_Name = station.SelectSingleNode("FileName").InnerXml;
                string File_ID = station.SelectSingleNode("FileID").InnerXml;
                grabber(File_Name, File_ID);
            }
        }
    
        static void grabber(string Name, string Id)
        {
            // grab it here
        }
    }
