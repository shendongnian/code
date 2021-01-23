    public static T Load<T>(string filename, IEnumerable<Type> typeList) where T : class, new()
        {
            if (!File.Exists(filename))
                return new T();
            TextReader fileStream = null;
            try
            {
                // Construct an instance of the XmlSerializer with the type
                // of object that is being deserialized.
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), typeList.ToArray());
                // To read the file, create a FileStream.
                fileStream = new StreamReader(filename);
                return xmlSerializer.Deserialize(fileStream) as T;
                // Call the Deserialize method and cast to the object type.
                //  return xmlSerializer.Deserialize(fileStream) as T;
            }
            catch (Exception ex)
            {
                return new T();
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();
            }
        }
