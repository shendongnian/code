    List<string> parameters = new List<string>();
            
    // reflection here?
    parameters.Add("ApiKey=" + request.ApiKey);
    // ... more request parameters here
    for (int i = 0; i < request.Rooms.Count; i++)
    {
        Room room = request.Rooms[i];
        for (int k = 0; room.Paxes.Count; k++)
        {
            Pax pax = room.Paxes[k];
            string roomParam = "room[" + i + "][" + k + "]";
            // reflection here?
            parameters.Add(roomParam + "[age]=" + pax.Age);
            // ... more pax parameters
        }
    }
    // we join all parameters get the query string
    string query = "?" + String.Join("&", parameters)
