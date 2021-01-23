            // serialize a helper class containing a card
            // use a local file for the example
            string path = System.IO.Path.GetTempFileName();
            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(path);
            serializeHelper toBeSerialized = new serializeHelper(new card());
            XmlSerializer xmlSer = new XmlSerializer(typeof(serializeHelper));
            xmlSer.Serialize(streamWriter, toBeSerialized);
            streamWriter.Close();
            // deserialize the helper class
            System.IO.StreamReader streamReader = new System.IO.StreamReader(path);
            XmlSerializer xmlDeser = new XmlSerializer(typeof(serializeHelper));
            serializeHelper wasDeserialized = (serializeHelper)(xmlDeser.Deserialize(streamReader));
            streamReader.Close();
            // get the type, and convert the package to the desired type
            
            Type t = Type.GetType(wasDeserialized.PackageType);
            object theFinalObject = Convert.ChangeType(wasDeserialized.Package, t);
