    // <summary>
	/// This POCO models an ElasticsearchProject that allows country to serialize to null explicitly
	/// So that we can use it to clear contents in the Update API
	/// </summary>
	public class PartialElasticsearchProjectWithNull
	{
		[JsonProperty(NullValueHandling = NullValueHandling.Include)]
		public string Country { get; set; }
	}
