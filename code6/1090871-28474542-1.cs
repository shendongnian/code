    private Playlist Load(string filename)
    {
        
        // Create an instance of the XmlSerializer specifying type and namespace.
        XmlSerializer serializer = new
        XmlSerializer(typeof(Playlist));
        // A FileStream is needed to read the XML document.
        FileStream fs = new FileStream(filename, FileMode.Open);
        XmlReader reader = XmlReader.Create(fs);
        // Declare an object variable of the type to be deserialized.
        Playlist i;
        // Use the Deserialize method to restore the object's state.
        i = (Playlist)serializer.Deserialize(reader);
        fs.Close();
        // Write out the properties of the object.
        return i;
    }
