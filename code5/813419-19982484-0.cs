    public class APIResponseProcessor : IResponseProcessor
    {
    	private static readonly IEnumerable<Tuple<string, MediaRange>> extensionMappings =
    		new[] {new Tuple<string, MediaRange>("json", MediaRange.FromString("application/json"))};
    
    	public ProcessorMatch CanProcess(MediaRange requestedMediaRange, dynamic model, NancyContext context)
    	{
    		var match = new ProcessorMatch();
    		match.ModelResult = MatchResult.DontCare;
    		match.RequestedContentTypeResult = MatchResult.ExactMatch;
    		
    		return match;
    	}
    
    	public Response Process(MediaRange requestedMediaRange, dynamic model, NancyContext context)
    	{
    		var apiResponse = new APIResponse();
    		apiResponse.Data = model;
    		
    		return new JsonResponse(apiResponse,new DefaultJsonSerializer());
    	}
    
    	public IEnumerable<Tuple<string, MediaRange>> ExtensionMappings { get { return extensionMappings; } }
    }
