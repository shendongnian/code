    public static void ReplaceCustomXML(WordprocessingDocument myDoc, string customXML)
        {
            MainDocumentPart mainPart = myDoc.MainDocumentPart;
            mainPart.DeleteParts<CustomXmlPart>(mainPart.CustomXmlParts);
            CustomXmlPart customXmlPart =     mainPart.AddCustomXmlPart(CustomXmlPartType.CustomXml);
            using (StreamWriter ts = new StreamWriter(customXmlPart.GetStream()))
            {
                ts.Write(customXML);
                ts.Flush();
                ts.Close();
            }
        }
    public static MemoryStream GetCustomXmlPart(MainDocumentPart mainPart)
        {
            foreach (CustomXmlPart part in mainPart.CustomXmlParts)
            {
                using (XmlTextReader reader =
                    new XmlTextReader(part.GetStream(FileMode.Open, FileAccess.Read)))
                {
                    reader.MoveToContent();
                    if (reader.Name.Equals("aaaa", StringComparison.OrdinalIgnoreCase))
                    {
                        string str = reader.ReadOuterXml();
                        byte[] byteArray = Encoding.ASCII.GetBytes(str);
                        MemoryStream stream = new MemoryStream(byteArray);
                        return stream;
                    }
                }
            }
            return null; //result;
        }
    using (WordprocessingDocument myDoc = WordprocessingDocument.Open(ms, true))
                    {
                        StreamReader reader = new StreamReader(memStream);
                        string FullXML = reader.ReadToEnd();
                        ReplaceCustomXML(myDoc, FullXML);
                        myDoc.Package.Flush();
                        //Code to save file
                    }
