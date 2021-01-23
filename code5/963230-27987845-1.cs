    private void SerializeObject(string filename, DataSource d)
        {
            try
            {
                XmlSerializer serializer =
                new XmlSerializer(typeof(DataSource));
                // Create an XmlTextWriter using a FileStream.
                Stream fs = new FileStream(filename, FileMode.Create);
                XmlWriter writer =
                new XmlTextWriter(fs, Encoding.Unicode);
                // Serialize using the XmlTextWriter.
                serializer.Serialize(writer, d);
                writer.Close();
            }
            catch (Exception e) { MessageBox.Show("inside serializeObject Method "+e.Message); }
        }
