    int[] numbers = new [] { 0, 1, 2, 3};
    XmlSerializer serializer = new XmlSerializer(typeof(int[]));
    var myString = serializer.Serialize(numbers);
    // Send your string over the wire
    m_writer.WriteLine(myString);
    m_writer.Flush();
    // On the other end, deserialize the data
    using(var memoryStream = new MemoryStream(data))
    {
        XmlSerializer serializer = new XmlSerializer(typeof(int[]));
        var numbers = (int[])serializer.Deserialize(memoryStream);
    }
