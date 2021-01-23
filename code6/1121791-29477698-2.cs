    // Used my own enums
    public enum MapTypes
    {
        One, Two, Three, Four, Five
    }
    // I had to make this static since it's being used in a static method
    static Random rnd = new Random();
    public static MapTypes GetMapType(string Type)
    {
        switch (Type.ToLower())
        {
            default:
            case "default":
                // Changed first parameter of Next to 0 to include the first enum in the randomization
                return (MapTypes)(rnd.Next(0, Enum.GetNames(typeof(MapTypes)).Length));
                break;
        }
    }
