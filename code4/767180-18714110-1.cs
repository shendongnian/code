    public class ScoreResult
    {
        public int Low { get; set; }
        public int High { get; set; }
        public string Status { get; set; }
        public double ReplacementScore { get; set; }
    
        public ScoreResult(int low, int high, string status, 
              double replacementScore)
        {
            Low = low;
            High = high;
            Status = status;
            ReplacementScore = replacementScore;
        }
    }
    
    public class ScoreCalculator
    {
        private List<ScoreResult> _scores = new List<ScoreResult>();
    
        public ScoreCalculator()
        {
            /*These are easy to change and could be
              loaded from a database/service*/
            _scores.Add(new ScoreResult(1, 10, "FAILED", 0));
            _scores.Add(new ScoreResult(10, 20, string.Empty, 1));
            _scores.Add(new ScoreResult(20, 30, string.Empty, 2));
            _scores.Add(new ScoreResult(30, 40, string.Empty, 3));
        }
    
        public ScoreResult GetScoreResult(int score)
        {
            //Will return null if no match found
                return _scores.FirstOrDefault
                        (s => score >= s.Low && score <= s.High);
        }
    }
