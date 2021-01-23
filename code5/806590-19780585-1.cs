    var item = new Customize() { Content = new List<Content> { new Content(), new Content() }, Command = new List<Command> { new Command(), new Command(), new Command() } };
    string result;
    using (var writer = new StringWriter())
    {
        var serializer = new XmlSerializer(typeof(Customize));
        serializer.Serialize(writer, item);
        result = writer.ToString();
    }
