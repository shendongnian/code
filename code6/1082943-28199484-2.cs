    public class ScoredSentence 
    {
        public string sentence { get; set; }
        public int score { get; set; }
        public ScoredSentence(string sentence, int score)
        {
            this.sentence = sentence;
            this.score = score;
        }
    }
