    public void Page_Load()
	{
	  Response.Cache.AddValidationCallback(new HttpCacheValidateHandler(ValidateCache), null);
	}
	public static void ValidateCache(HttpContext context, Object data, ref HttpValidationStatus status) 
	{
		validationstatus = context.Request.Headers["myheaders"]=="nocache" ? HttpValidationStatus.IgnoreThisRequest : HttpValidationStatus.Valid;
	}
