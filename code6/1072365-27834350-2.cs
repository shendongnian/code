    public static string SerializeToString<T>(this T toSerialize)
    {
        XmlSerializer serializer = new XmlSerializer(toSerialize.GetType());
        using (StringWriter textWriter = new StringWriter())
        {
            serializer.Serialize(textWriter, toSerialize);
            textWriter.Flush();
            return textWriter.ToString();
        }
    }
