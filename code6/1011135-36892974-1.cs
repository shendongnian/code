	[HttpDelete]
	[Route("api/product/{productId}")]
    public HttpResponseMessage Delete(int productId)
	{
		if (values.Count > index) {
			values.RemoveAt(index);
		}
	}
