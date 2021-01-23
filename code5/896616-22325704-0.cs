    public static void Save<T>(T item, string filename, IEnumerable<Type> typeList) where T : class, new()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), typeList.ToArray());
            // To write to a file, create a StreamWriter object.
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(filename);
                var ns = new XmlSerializerNamespaces();
                ns.Add(string.Empty, string.Empty);
                xmlSerializer.Serialize(writer, item, ns);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
