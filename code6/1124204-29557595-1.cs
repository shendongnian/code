    public static Result<int> GetParameter(this Dictionary<string, string> context, string parameterName)
    {
        string stringParameter;
        context.TryGetValue(parameterName, out stringParameter);
        int result;
        if (int.TryParse(stringParameter, out result))
            return Result<int>.Success(result);
        else
            return Result<int>.Failure();
    }
