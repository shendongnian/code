    public Library DeserializeLibrary(string path)
    {
        Library result;
        XmlSerializer mySerializer = new XmlSerializer(typeof(Library));
        // To read the file, create a FileStream.
        using (FileStream myFileStream = new FileStream(path, FileMode.Open))
        {
            // Call the Deserialize method and cast to the object type.
            result = (Library)mySerializer.Deserialize(myFileStream);
        }
        return result;
    }
