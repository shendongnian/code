    // BuildTypeModel could be called from the Constructor
    // and then stored in a TypeModel variable inside the class
    var serializer = new CustomProtoBufSerializer();
    var serialized = serializer.Serialize(someClassInput);
    SomeClass someClassOutput = serializer.Deserialize(serialized);
