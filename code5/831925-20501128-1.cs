        #region static T DeserializeObject( string xml, Encoding encoding )
        /// <summary>
        ///   Deserialize an Xml String to an [object]
        /// </summary>
        /// <typeparam name="T">Object Type to Deserialize</typeparam>
        /// <param name="xml">Xml String to Deserialize</param>
        /// <param name="encoding">System.Text.Encoding Type</param>
        /// <returns>Default if Exception, Deserialize object if successful</returns>
        /// <example>
        ///   // UTF-16 Deserialize
        ///   [object] = SerializationHelper<ObjectType>DeserializeObject( xml, Encoding.Unicode )
        /// </example>
        /// <example>
        ///   // UTF-8 Deserialize
        ///   [object] = SerializationHelper<ObjectType>DeserializeObject( xml, Encoding.UTF8 )
        /// </example> 
        public static T DeserializeObject(string xml, Encoding encoding)
        {
            if (string.IsNullOrEmpty(xml)) { return default(T); }
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                using (MemoryStream memoryStream = new MemoryStream(encoding.GetBytes(xml)))
                {
                    // No settings need modifying here
                    XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
                    using (XmlReader xmlReader = XmlReader.Create(memoryStream, xmlReaderSettings))
                    {
                        return (T)xmlSerializer.Deserialize(xmlReader);
                    }
                }
            }
            catch
            {
                return default(T);
            }
        }
        #endregion
        /// <summary>
        /// Deserialize an Xml String to an [object] with UTF8 as Encoding
        /// </summary>
        /// <param name="xml">Xml String to Deserialize</param>
        /// <returns>Default if Exception, Deserialize object if successful</returns>
        /// <example>
        ///   [object] = SerializationHelper<ObjectType>DeserializeObject( xml )
        /// </example>
        public static T DeserializeObjectFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(string.Format("The file {0}, don't exist.", filePath));
            }
            StreamReader sr = File.OpenText(filePath);
            string xml = sr.ReadToEnd();
            return DeserializeObject(xml, Encoding.UTF8);
        }
