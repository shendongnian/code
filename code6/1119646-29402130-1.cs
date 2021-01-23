    public void Post(HttpRequestMessage request)
    {
        using (var xmlReader = XmlReader.Create(request.Content.ReadAsStreamAsync().Result))
        {
            xmlReader.MoveToContent();
            switch (xmlReader.Name)
            {
                case "First":
                    HandleFirst(Deserialize<First>(xmlReader));
                    break;
                case "Second":
                    HandleSecond(Deserialize<Second>(xmlReader));
                    break;
                default:
                    throw new NotSupportedException();
            }
        }
    }
    
    private T Deserialize<T>(XmlReader xmlReader)
    {
        var serializer = new XmlSerializer(typeof(T));
        return (T)serializer.Deserialize(xmlReader);
    }
