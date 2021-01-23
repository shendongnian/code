    [ModelBinder(typeof(CustomJsonModelBinder))]
    public class GetUsersFromNextCircuitRequest
    {
        public int? dosarId { get; set; }
        public List<int> dosareIds { get; set; }
        public string query { get; set; }
        public int page { get; set; }
        public int page_limit { get; set; }
    }
