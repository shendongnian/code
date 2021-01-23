    class Program
    {
        static void Main(string[] args)
        {
            string startPath = @"c:\Temp\att\";
            string xmlpath = @"c:\Temp\log\";
            var files = Directory.GetFiles(xmlpath, "*.*", SearchOption.AllDirectories)
            .Where(s => s.EndsWith(".xml"));
            foreach (string xml in files)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xml);
                XmlNodeList Xe = doc.SelectNodes("//FileDump/Message/Attachment");
                var Message_ID = doc.SelectSingleNode("//FileDump/Message/MsgID").InnerXml;
                foreach (XmlNode Xn in Xe)
                {
                    var linkNode = Xn.SelectSingleNode("FileName");
                    if (linkNode != null)
                    {
                        string link = linkNode.InnerText.Trim();
                    }
                    string File_Name = Xn.SelectSingleNode("FileName").InnerXml;
                    string File_ID = Xn.SelectSingleNode("FileID").InnerXml;
                    //System.IO.File.Copy(curFile, msgsave, true);
                    
                }
                try
                {
                    string msgsave = @"c:\Temp\ZIP\" + doc.SelectSingleNode("//FileDump/Message/Attachment/FileName").InnerXml;
                    string curFile = startPath + doc.SelectSingleNode("//FileDump/Message/Attachment/FileName").InnerXml;
                    string bbgfile = xmlpath + "MR_" + Message_ID + ".xml";
                    string zipfilename = "MR_" + Message_ID + ".zip";
                    string rkzip = System.IO.Path.Combine(@"C:\Temp\log\", zipfilename);
                    using (ZipFile zip = new ZipFile())
                    {
                        string zipFileName = System.IO.Path.Combine(@"C:\Temp\log\", "MR_" + Message_ID + ".zip");
                        zip.AddFile(curFile, "");
                        zip.AddFile(bbgfile, "");
                        zip.Save(rkzip);
                    }
                }
