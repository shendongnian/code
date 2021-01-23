        public static void SaveDocument(System.Xml.XmlDocument doc, string strFilename, bool bDoReplace)
        {
            string strSavePath = GetSavePath();
            strSavePath = System.IO.Path.Combine(strSavePath, System.IO.Path.GetFileName(strFilename));
            if (bDoReplace)
            {
                doc.LoadXml(doc.OuterXml.Replace("xmlns=\"\"", ""));
                // doc.LoadXml(doc.OuterXml.Replace(strTextToReplace, strReplacementText));
            }
            
            using (System.Xml.XmlTextWriter xtw = new System.Xml.XmlTextWriter(strSavePath, System.Text.Encoding.UTF8))
            {
                xtw.Formatting = System.Xml.Formatting.Indented; // if you want it indented
                xtw.Indentation = 4;
                xtw.IndentChar = ' ';
                doc.Save(xtw);
            } // End Using xtw
        } // End Sub SaveDocument
