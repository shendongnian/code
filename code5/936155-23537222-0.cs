    public static ServersList LoadList(string _FileName)
        {
            using (StreamReader reader = new StreamReader(_FileName))
            {
                return (BusinessObjects.ServersList)serializer.Deserialize(reader);
            }
        }
