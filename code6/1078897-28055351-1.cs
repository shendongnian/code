    public void Load()
    {
        // ... Deserialize
        Party data = (Party)serializer.Deserialize(stream);
        this.Name = data.Name;
        this.PartyInfo = data.PartyInfo;
    } 
