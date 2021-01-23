    public static T DeserializeObject<T>(string fileName)
    {
        T retValue = default(T);
        if (string.IsNullOrEmpty(fileName)) 
            return retValue;
    
        FileStream fs = new FileStream(fileName, FileMode.Open);
        BinaryFormatter formatter = new BinaryFormatter();
        try
        {
            retValue = (T)formatter.Deserialize(fs);
        }
        catch (Exception ex)
        {
            Trace.WriteLine("Can't De-Serialise" + ex.ToString());
        }
        finally
        {
            fs.Close();
        }
    
        return retValue;
    }
