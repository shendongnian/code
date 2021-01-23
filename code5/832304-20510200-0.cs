    FileStream fs = new FileStream(filepath, FileMode.Open);
    List<Vechicle> Vechicles = null;
    List<Journey> Journeys = null;
    try 
    {
        XmlSerializer SerializerObj = new XmlSerializer(typeof(List<Vechicle>));
        Vechicles = ((List<Vechicle>)SerializerObj.Deserialize(fs));
    }
    catch
    {
        Type [] extraTypes= new Type[] { typeof(Tour) };
        XmlSerializer SerializerObj = new XmlSerializer(saveType, extraTypes);
        Journeys = ((List<Journey>)SerializerObj.Deserialize(fs));
    }
    if ( Vechicles != null)
    {
      // do something
    } 
    else if ( Journeys != null)
    {
      // do something
    }
