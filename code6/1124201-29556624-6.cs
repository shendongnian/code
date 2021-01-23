    public class ParseResult
    {
        public ParseResult(bool IsSuccess, int Result)
        {
            this.IsSuccess = IsSuccess;
            this.Result = Result;
        }
        public bool IsSuccess { get; set; }
        public int Result { get; set; }
    }
    public static ParseResult GetParameter(this Dictionary<string, string> context, string parameterName)
    { 
        int ret;
        string stringParameter; 
        if (context.TryGetValue(parameterName, out stringParameter)
            && int.TryParse(stringParameter, out ret))
        {
            return new ParseResult(true, ret);
        }
        else
        {
            return new ParseResult(false, 0);
        }
    }
