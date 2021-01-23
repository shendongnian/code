	[HttpDelete]
	[Route("api/product/{productId}")]
    public HttpResponseMessage Delete(int productId)
	{
		if (values.Count > productId) {
			values.RemoveAt(productId);
		}
	}
