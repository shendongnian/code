    List<Clients> _listOfClientCache ; 
    
    private client[] GetSClientsByCity(string city)
    {
       _listOfClient.Where(x => x.Client.City = city).ToArray();
    }
