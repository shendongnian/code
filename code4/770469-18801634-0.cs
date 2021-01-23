    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service : IService
	{
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public bool MatchPartial(string partialFilename)
        {
            ...
        }
	}
