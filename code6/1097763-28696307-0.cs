    public class CardResponseWrapper
    {
        public int count { get; set; }
        public int startIndex { get; set; }
        public int endIndex { get; set; }
        public bool is_more { get; set; }
        public List<Cards.CardResponse> data { get; set; }
    }
