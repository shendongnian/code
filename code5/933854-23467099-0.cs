    public class RecipesController : ApiController
    {
        private readonly RecipeModel _recipeModel = new RecipeModel();
    
    	[ActionName("Division")]
    	public HttpResponseMessage GetRecipeByDivisionId(int id)
    	{
    		HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
    
    		var adoria = _recipeModel.GetRecipeByDivisionId(id);
    
    		XmlSerializer serializer = new XmlSerializer(typeof(Adoria));
    		using (MemoryStream memoryStream = new MemoryStream())
    		{
    			using (XmlWriter xmlWriter = XmlWriter.Create(memoryStream))
    			{
    				serializer.Serialize(xmlWriter, adoria);
    			}
    
    			result.Content = new StreamContent(memoryStream);
    			result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
    
    			return result;
    		}
    	}
    }
