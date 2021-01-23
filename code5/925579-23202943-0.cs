    public static object LoadObject()
     {
       try
         {
           if (File.Exists("D://my.bin"))
             {
                FileStream stream = File.OpenRead("D://my.bin");
                BinaryFormatter formatter = new BinaryFormatter();
                Dictionary<int, Question> deserializedObject = (Dictionary<int, Question>)formatter.Deserialize(stream);
                stream.Close();
                return deserializedObject;
             }
         }
        catch
           {
             return null;
           }
         return null;
     }
