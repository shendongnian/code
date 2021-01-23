    string[] lines = File.ReadAllLines("data.ics");
    var events = new List<Dictionary<string, string>>();
    int eventIndex = -1;
    foreach (var line in lines)
    {
        if (line == "BEGIN:VEVENT")
        {
            events.Add(new Dictionary<string,string>());
            eventIndex++;
        }
        else if (line != "END:VEVENT")
        {
            int positionOfColon = line.IndexOf(':');
            if (positionOfColon == -1) continue;
            string propertyName = line.Substring(0, positionOfColon - 1);
            string propertyValue = line.Substring(positionOfColon + 1);
            events[eventIndex].Add(propertyName, propertyValue);
        }
    }
