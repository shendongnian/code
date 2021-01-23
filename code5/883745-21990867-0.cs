            using (System.IO.MemoryStream stream = new System.IO.MemoryStream (Encoding.Default.GetBytes(strXML.ToString())))
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.DtdProcessing = DtdProcessing.Prohibit;
                using (XmlReader reader = XmlReader.Create(stream, settings))
                {
                    try
                    {
                        xmlDoc.Load(reader);
                    }
                    catch(XmlException e)
                    {
                    }
                }
            }
