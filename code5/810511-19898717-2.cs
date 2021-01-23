    serializer.UnknownElement += (obj, eargs) =>
    {
      var element = eargs.Element;
      var book = eargs.ObjectBeingDeserialized as Book;
      
      //Are we deserializing a book and do we have an unrecognized Thing element?
      if (book != null && element.Name.StartsWith("Thing"))
      {            
        //Deserialize our thing
        using (var stringReader = new StringReader(element.OuterXml))
        {
          var thingSerializer = new XmlSerializer(typeof(Thing), new XmlRootAttribute(element.Name));
          var thing = (Thing)thingSerializer.Deserialize(stringReader);
          //Name can't be mapped for us, assign this manually
          thing.Name = element.Name;
          book.Things.Add(thing);
        }
      }
    };
