        var suspectConnections = new List<SuspectConnection>();
        foreach (var suspect in suspects)
        {
            var connection = new SuspectConnection() { SuspectId = suspect };
            connection.Contacts = logs.Where(x => x.From == suspect).Select(x => x.To).ToList();
            suspectConnections.Add(connection);
        }
