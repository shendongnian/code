    [Serializable()]
    public class HighScore {
        public int Score { get; set; }
        public string Initials { get; set; }
    }
    public List<HighScore> _highScores = new List<HighScore>();
