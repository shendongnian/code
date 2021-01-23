    public class MyViewModel
    {
        public string PageTitle { get; set; }
        public DocumentList DocList { get; set; }
        // You could use your DocumentList object here, or if you
        // don't want to, just pass a List<T> of Document
        public List<Document> DocList { get; set; }
    }
