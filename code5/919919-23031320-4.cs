        private MemoryStream ProcessMemoryStream(Stream inputStream, bool dispose)
        {
            StreamWriter xmlStream = null;
            var outputStream = new MemoryStream();
            bool continueFilter = false;
            try
            {
                xmlStream = new StreamWriter(outputStream);
                using (var reader = XmlReader.Create(inputStream))
                {
                    using (
                        var writer = XmlWriter.Create(xmlStream,
                            new XmlWriterSettings() {ConformanceLevel = ConformanceLevel.Auto}))
                    {
                        while (reader.Read())
                        {
                            if (reader.LocalName.Equals("SignatureConfirmation") &&
                                reader.NamespaceURI.Equals(
                                    "http://docs.oasis-open.org/wss/oasis-wss-wssecurity-secext-1.1.xsd"))
                            {
                                if (!reader.IsEmptyElement) continueFilter = reader.IsStartElement();
                            }
                            else if (reader.LocalName.Equals("Signature") &&
                                     reader.NamespaceURI.Equals("http://www.w3.org/2000/09/xmldsig#"))
                            {
                                if (!reader.IsEmptyElement) continueFilter = reader.IsStartElement();
                            }
                            else if (continueFilter)
                            {
                               // continue to next node
                            }
                            else
                                XmlHelper.WriteShallowNode(reader, writer);
                        }
                        writer.Flush();
                    }
                    reader.Close();
                }
                outputStream.Position = 0;
                return outputStream;
            }
            catch (Exception ex)
            {
                // handle error
                throw;
            }
            finally
            {
                if (xmlStream != null && dispose) xmlStream.Dispose();
            }
        }
