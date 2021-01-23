            using (var ms = new MemoryStream())
            {
                try
                {
                    string xml = string.Empty;
                    var dcs = new DataContractSerializer(this.GetType());
                    using (var xmlTextWriter = new XmlTextWriter(ms, Encoding.Default))
                    {
                        xmlTextWriter.Formatting = Formatting.Indented;
                        dcs.WriteObject(xmlTextWriter, this);
                        xmlTextWriter.Flush();
                        var item = (MemoryStream)xmlTextWriter.BaseStream;
                        item.Flush();
                        xml = new UTF8Encoding().GetString(item.ToArray());
                    }
                }
                finally
                {
                    ms.Close();
                }
            }
            return xml;
