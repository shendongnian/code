    public interface IAdditionalParams
    {
        List<string> SupportedParams { get; }
        object GetParam(string supportedParam);
    }
