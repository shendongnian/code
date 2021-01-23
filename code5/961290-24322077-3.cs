       var roomsIterate = new List<string>();
        foreach (var h in houses)
        {
            for (int i = 1; i < h.Rooms + 1; i++)
            {
                roomsIterate.Add(h.Name + ", room " + i);
            }
        }
