    [Route("/api/keywords/processchecked", "POST")]
    public class RequestCheckedKeywords : IReturn<Response>
    {
        public List<CheckedKeyword> CheckedKeywords { get; set; }
    }
    public class CheckedKeyword
    {
        public string Keyword { get; set; }
        public int TotalNum { get; set; }
        public string State { get; set; }
        public string Updatetime { get; set; }
        public bool IsChecked { get; set; }
    }
    public class KeywordsServices : Service
    {
        public Response Post(RequestCheckedKeywords request)
        {
            return new Response { Result = 1, Message = "" };
        }
    }
