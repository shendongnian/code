    `Drawing tDraw = pControl.Descendants<Drawing>().FirstOrDefault();
    //if there is a drawing element, then clone control
    OpenXmlElement tClone = (OpenXmlElement)pControl.Clone();
    //then call method: 
     private static void insertPicture(OpenXmlElement pControl)
        {
            //WordprocessingDocument wordDoc = WordprocessingDocument.Open(dokument, true);
            MainDocumentPart mainPart = dokument.MainDocumentPart;
            CustomXmlPart customPart = mainPart.CustomXmlParts.FirstOrDefault();
            //convert image into string
            string picName = @"c:\temp\picasso.png";
            System.IO.FileStream fileStream = System.IO.File.Open(picName, System.IO.FileMode.Open);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fileStream);
            byte[] byteArea;
            byteArea = br.ReadBytes(System.Convert.ToInt32(fileStream.Length));
            string picString = System.Convert.ToBase64String(byteArea);
            //Load the XML template
            string DataString = iData["DATA"].ToString();
            //Properties.Resources.XMLData;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(DataString);
            //change the value
            XmlNodeList xmlNode = xmlDoc.GetElementsByTagName("picture");
            xmlNode[0].InnerText = picString;
            //write the custom xml data into the customxmlpart
            System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(customPart.GetStream(System.IO.FileMode.Create), System.Text.Encoding.UTF8);
            writer.WriteRaw(xmlDoc.InnerXml);
            writer.Flush();
            writer.Close();
            fileStream.Close();
            br.Close();
            mainPart.Document.Save();
            //dokument.Close();
        }
    then append control to document
    OpenXmlElement tC1 = pControl;
                IEnumerable<Run> tEl1 = tClone.Descendants<Run>();
                if (tEl1.Count() != 0)
                {
                    foreach (OpenXmlElement tElement in tEl1.Reverse())
                    {
                        OpenXmlElement tClone1 = (OpenXmlElement)tElement.Clone();
                        tC1.InsertBeforeSelf(tClone1);
                        tC1 = tClone1;
                    }
                }`
