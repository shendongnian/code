     public void test()
        {
            Stereo [] noteBuffer = new noteBuffer[ 128 ];
           SerializeToXml<List<Stereo>>(noteBuffer.ToList(), outfile);
        }
        
        
        
        public static T DeserializeFromXml<T>(string inputFile)
        {
            XmlSerializer s = new XmlSerializer(typeof(T));
            T deserializedObject = default(T);
        
            using (TextReader textReader = new StreamReader(inputFile))
            {
                deserializedObject = (T)s.Deserialize(textReader);
                textReader.Close();
            }
        
            return deserializedObject;
        }
        
        public static void SerializeToXml<T>(T objToSerialize, string outputFile)
        {
        
            XmlSerializer s = new XmlSerializer(objToSerialize.GetType());
        
            using (TextWriter textWriter = new StreamWriter(outputFile))
            {
                s.Serialize(textWriter, objToSerialize);
                textWriter.Close();
            }
        }
