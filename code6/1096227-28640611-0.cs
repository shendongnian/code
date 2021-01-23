    var folder = ApplicationData.Current.LocalFolder;
    try
    {
        using (var connectionsFile = await folder.OpenStreamForReadAsync("connections"))
        using (var streamReader = new StreamReader(connectionsFile, Encoding.Unicode))
        {
            while (!streamReader.EndOfStream)
            {
                String con = await streamReader.ReadLineAsync();
                String[] props = con.Split('\t');
                Connection newConnection = new Connection() {Name = props[0], Url = props[1]};
                ConnectionsCollection.Add(newCollection);
            }
        }
    }
    catch (Exception e)
    {
        //handle exception
    }
