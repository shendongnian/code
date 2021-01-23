    var dic = new SerializableSortedDictionary<string, Car>();
    dic.Add("0", new Car());
    dic.Add("1", new Audi());
    dic.Add("2", new Volvo());
    var serializer = new XmlSerializer(typeof(SerializableSortedDictionary<string, Car>));
    var builder = new StringBuilder();
    using(var writer = new StringWriter(builder)) {
      serializer.Serialize(writer, dic);
    }
