    public class FactViewModel
    {
        public int AssessmentID { get; set; }
        public IEnumerable<MobilityScore> MobilityScores { get; set; }
        public IEnumerable<SocialScore> SocialScores { get; set; }
        public IEnumerable<FunctionScore> FunctionScores { get; set; }
        public IEnumerable<CognitionScore> CognitionScores { get; set; }
        public IENumerable<Score> Scores
        {
            get
            {
                var scores = new List<Score>();
                scores.Add(MobilityScores);
                scores.Add(SocialScores);
                scores.Add(FunctionScores);
                scores.Add(CognitionScores);
                // Order
                return scores
            }
        }
    }
