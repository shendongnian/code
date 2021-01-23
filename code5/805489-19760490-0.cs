    static void Main(string[] args)
    {
        XmlDocument xml = new XmlDocument();
        xml.Load(@"C:\Temp\XML\MR.xml");
        XmlNodeList Xe = xml.SelectNodes("//FileDump/Message/Attachment");
        var Message_ID = xml.SelectSingleNode("//FileDump/Message/MsgID").InnerXml;
        Console.WriteLine("Message ID is :{0}", Message_ID);
        foreach (XmlNode Xn in Xe)
        {
            string File_Name = Xn.SelectSingleNode("FileName").InnerXml;
            string File_ID = Xn.SelectSingleNode("FileID").InnerXml;
            grabber(File_Name, File_ID);
        }
        }
        static void grabber(string Name, string Id)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(@"C:\Temp\XML\MR.xml");
            string curFile = @"c:\Temp\att\" + xml.SelectSingleNode("//FileDump/Message/Attachment/FileName").InnerXml;
            string bbgfile = @"c:\Temp\xml\" + "MR_" + xml.SelectSingleNode("//FileDump/Message/MsgID").InnerXml + ".xml";
            string zipfilename = "MR_" + xml.SelectSingleNode("//FileDump/Message/MsgID").InnerXml + ".zip";
            string rkzip = System.IO.Path.Combine(@"C:\Temp\ZIP\", zipfilename);
            //Console.WriteLine(File.Exists(curFile) ? "Attachement File Name: " + File_Name + " exists." : "File does not exist.");
            //Console.ReadLine();
            string msgsave = @"c:\Temp\ZIP\" + xml.SelectSingleNode("//FileDump/Message/Attachment/FileName");
            //System.IO.File.Copy(curFile, msgsave, true);
            using (ZipFile zip = new ZipFile())
            {
                string zipFileName = System.IO.Path.Combine(@"C:\Temp\ZIP\", "MR_" + xml.SelectSingleNode("//FileDump/Message/MsgID").InnerXml + ".zip");
                zip.AddFile(curFile, "");
                zip.AddFile(bbgfile, "");
                zip.Save(rkzip);
            }
        }
