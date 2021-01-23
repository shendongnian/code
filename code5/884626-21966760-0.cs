    public class SearchModel
    {
    	public string Query { get; set; }
    }
    public class SearchController
    {
    	[HttpPost]
    	public ActionResult Search(SearchModel data)
    	{
    		...
    	}
    }
    @model SearchModel
    @using(Html.BeginForm("Search", "Search", FormMethod.Post))
    {
    	@:Html.EditorFor(model => model.Query);
    }
