    public Participant GetById(string id)
    {       
       return this.Redis.GetById<Participant>(id);
    }
    public List<Connection> GetForwardConnections(string participantId)
    {       
       return this.Redis.GetTypedClient<Connection>().Lists["urn:participant:1:forwardconnections"].ToList();
    }
    public List<Connection> GetReverseConnections(string participantId)
    {       
       return this.Redis.GetTypedClient<Connection>().Lists["urn:participant:1:reverseconnections"].ToList(); // you could also use sets 
    }
