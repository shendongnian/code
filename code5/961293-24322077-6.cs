        var list = new List<IEnumerable<string>>();
        foreach (var h in houses)
        {
            var rooms = new List<string>();
            for (int i = 1; i < h.Rooms + 1; i++)
            {
                rooms.Add(h.Name + ", room " + i);
            }
            list.Add(rooms);
        }
