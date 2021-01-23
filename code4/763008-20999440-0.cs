    Persons : List < Person > should be also Serializable.
    
    public void GetObjectData( SerializationInfo info, StreamingContext context )
    
    {
    
    
    
    foreach (Person person in this)
    
    {
    if(person.HasValue)
    {
    info.AddValue("Firsname", person, typeof(Person));
    
    info.AddValue (....);
    
    ..............
    
    }
    
    }
