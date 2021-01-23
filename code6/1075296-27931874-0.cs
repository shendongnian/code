    T Try(Func<T> method)
	{
		try
		{
			return method.Invoke();
		}
		catch (TimeoutException ex)
		{
			return Request.CreateErrorResponse(HttpStatusCode.RequestTimeout, ex.Message);
		}
		catch (UnauthorizedAccessException ex)
		{
			return Request.CreateErrorResponse(HttpStatusCode.Forbidden, ex.Message);
		}
		catch (Exception)
		{
			return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Unable to process your request.");
		}  
	}
