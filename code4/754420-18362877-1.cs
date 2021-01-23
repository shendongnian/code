     public static Object Deserialize(String stringObject)
        {
            Object returnObject;
            byte[] bytes = Convert.FromBase64String(stringObject);
            MemoryStream stream = new MemoryStream(bytes);
            BinaryFormatter bformatter = new BinaryFormatter();
            returnObject = bformatter.Deserialize(stream);
            return returnObject;
        }
