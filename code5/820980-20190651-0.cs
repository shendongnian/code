    List<IAnimal> animals = new List<IAnimal>();
    for (int i = 0; i <= 200; i += 2)
    {
      //Functions of IAnimal take int values so the string needs to be converted.
      int nooID = Convert.ToInt32(animalist[i]);
      //Create a new animal for every iteration and assign it the new ID/name.
      IAnimal nooanimal = new IAnimal();
      nooanimal.setID(nooID);
      nooanimal.setname(nooID);
      animals.Add(nooanimal);
    }
    System.Xml.Serialization.XmlSerializer serializer = 
        new System.Xml.Serialization.XmlSerializer(typeof(List<IAnimal>));
    using (StreamWriter streamWriter = System.IO.File.AppendText("animalist.xml"))
    {
        serializer.Serialize(streamWriter, animals);
    }
