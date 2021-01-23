    MeetingRoom setOptions(string hasProjectorValue, string propertyValue)
    {
        PropertyOptions prop;
        Enum.TryParse(propertyValue, true, out prop)
        return new MeetingRoom()
        {                    
            hasProjector = bool.Parse(hasProjectorValue),
            property = prop
        }
    }
