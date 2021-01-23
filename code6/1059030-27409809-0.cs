    public static bool DeSerializeAnyObject(out Object MyObj, Type MyType, string fileName)
    {
    
        if (string.IsNullOrEmpty(fileName)) { return false; }
    
        FileStream fs = new FileStream(fileName, FileMode.Open);
        BinaryFormatter formatter = new BinaryFormatter();
        try
        {
            MyObj = Convert.ChangeType(MyTypeformatter.Deserialize(fs), MyType);
        }
        catch (Exception ex)
        {
            Trace.WriteLine("Can't De-Serialise or Convert: " + ex.ToString());
            return false;
        }
        finally
        {
            fs.Close();
        }
    
       return true; 
    }
