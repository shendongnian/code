    public static Person Parse(string jsonString)
    {
        if (String.IsNullOrWhiteSpace(jsonString)) throw new ArgumentNullException("The jsonString parameter shouldn't be null or an empty string.");
        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Person));
        using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
        {
            return (Person)ser.ReadObject(stream);
        }
    }
    public static bool TryParse(string jsonString, out AlertPacket result)
    {
        try
        {
            result = AlertPacket.Parse(jsonString);
            return true;
        }
        catch (Exception ex)
        {
            if (ex is ArgumentNullException || ex is SerializationException)
            {
                result = null;
                return false;
            }
            throw;
        }
    }
