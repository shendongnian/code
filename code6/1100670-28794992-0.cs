    public class Offer {
        public string offerTitle { get; set; }
        public string offerDescription { get; set; }
        public string offerLocation { get; set; }
        public Offer():this("title") {
            
        }
        public Offer(string offerTitle) {
            this.offerTitle = offerTitle;
        }
    }
