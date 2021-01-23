        public override string ToString()
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ABC));
            string str;
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.WriteObject(stream, this);
                stream.Position = 0;
                using (StreamReader streamReader = new StreamReader(stream, Encoding.UTF8))
                {
                    str = streamReader.ReadToEnd();
                }
            }
            return str;
    }
