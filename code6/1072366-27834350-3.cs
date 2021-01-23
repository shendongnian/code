        public static string SerializeToString<T>(this T toSerialize)
        {
            XmlSerializer serializer = new XmlSerializer(toSerialize.GetType());
            StringBuilder stringBuilder = new StringBuilder();
            
            using (StringWriter textWriter = new StringWriter(stringBuilder))
            {
                serializer.Serialize(textWriter, toSerialize);
            }
            return stringBuilder.ToString();
        }
