        var suspectConnections = new List<SuspectConnection>();
        foreach (var suspect in suspects)
        {
            var connection = new SuspectConnection() { SuspectId = suspect };
            connection.Contacts = logs.Where(x => x.From == suspect || x.To == suspect).Select(x => x.From == suspect ? x.To : x.From).ToList();
            suspectConnections.Add(connection);
        }
