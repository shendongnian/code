    public class ThesisWithKeywordsModel
    {
        public Thesis thesis { get; set; }
        public IList<Keyword> keywords { get; set; }
        public IEnumerable<int> checkboxList { get; set; }
    }
