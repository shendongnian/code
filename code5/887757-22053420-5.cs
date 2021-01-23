    public class EligiblePositions
    {
        [JsonConverter(typeof(StringConverter))] // <-- See This
        public List<string> position { get; set; }
    }
    public class Player
    {
        public EligiblePositions eligible_positions { get; set; }
    }
    public class SportsAPI
    {
        public List<Player> player { get; set; }
    }
