    string xml = @"<?xml version=""1.0"" encoding=""utf-8""?>
    <GameArray xmlns=""http://foo.bar"">
        <Game>
        <Id>int</Id>
        <Title>string</Title>
        </Game>
        <Game>
        <Id>int</Id>
        <Title>string</Title>
        </Game>
    </GameArray>";
    XmlSerializer ser = new XmlSerializer(typeof(Game[]), 
                                            new XmlRootAttribute("GameArray") { Namespace = "http://foo.bar" });
    var games = (Game[])ser.Deserialize(new StringReader(xml));
