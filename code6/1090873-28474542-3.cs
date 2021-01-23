    private Playlist Load(string filename)
    {
        Playlist playlist;
        // Create an instance of the XmlSerializer specifying type and namespace.
        var serializer = new
        XmlSerializer(typeof(Playlist));
    
        // A FileStream is needed to read the XML document.
        using (var fs = new FileStream(filename, FileMode.Open))
        {
            using (var reader = XmlReader.Create(fs))
            {
                playlist = (Playlist) serializer.Deserialize(reader);
                fs.Close();
            }
        }
        return playlist;
    }
