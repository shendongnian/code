        XmlSerializer deserializer = new XmlSerializer(typeof(root));
        List<myObject> objectList = new List<myObject>();
        try
        {
            using (TextReader textReader = new StreamReader(xmlPath))
            {
                root setOfObjects;
                setOfObjects = (root)deserializer.Deserialize(textReader);
            }
            objectList = setOfObjects.A_Object;
         }
         catch(FileNotFoundException a)
         { }
         return objectList;
    }
