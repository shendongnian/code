    public static void SerializeToCsv(LabelRequest labelRequest, string fileName)
            {
                 if (labelRequest == null)
                    throw new ArgumentNullException("labelRequest");
                 StringBuilder sb = new StringBuilder();
                 
                foreach (PropertyInfo info in labelRequest.GetType() .GetProperties()) 
                {
                       object value =   info.GetValue(labelRequest, null);
                        sb.Append(value);
                        sb.Append(", ");
                 } 
                 sb.AppendLine();
                 using (StreamWriter stream = new StreamWriter(fileName))
                 {
                     stream.Write(sb.ToString());
                 }
            }
