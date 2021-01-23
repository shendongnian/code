    IQueryResponse
    {
        SomeModel model { get; set; }
        SomeMessage message { get; set; }
        SomeStatus status { get; set; }
    }
    public partial class SearchKMQueryResponse : IQueryResponse { }
    public partial class TopSolutionsKMQueryResponse : IQueryResponse { }
