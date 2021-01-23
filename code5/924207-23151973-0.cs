        public static class LabelRequestSerializer
        {
            public static Label DeserializeXmlFile(string fileName)
            {
               using (TextReader txtReader = new StreamReader(fileName))
               {
                   XmlSerializer xmlSerializer = new XmlSerializer(typeof(LabelRequest));
                   LabelRequest label = (LabelRequest) xmlSerializer.Deserialize(txtReader);
               }
            }
            public static coid SerializeToCsv(LabelRequest labelRequest, string fileName)
            {
                 if (labelRequest == null)
                    throw new ArgumentNullEception("labelRequest");
                 StringBuilder sb = new StringBuilder();
                 sb.Append(labelRequest.weightoz);
                 sb.Append(",");
                 sb.Append(labelRequest.mailclass);
                 sb.AppendLine();
                 using (StreamWriter stream = new StreamWriter(fileName))
                 {
                     stream.Write(sb.ToString());
                 }
            }
        }
