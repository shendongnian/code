    public enum AllowedParams
	{
	        StringA = 2,
	        StringB = 4,
	        StringC = 8,
	}
    public void SomeMethod(string param1, AllowedParams SentParam)
    {
        if (SentParam.HasFlag(AllowedParams.StringA) | SentParam.HasFlag(AllowedParams.StringB))
        {
        }
    }
