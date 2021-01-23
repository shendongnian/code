    [WebServiceAuthentication]
    public HttpResponseMessage Get(DocumentRequestModel requestForm)
    {
    	var response = CreateResponse(HttpStatusCode.OK);
    	response.Content = new ByteArrayContent(this.documentService.GetDocument(requestForm.DocumentId.ToString()));
    	response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
    	return response;
    }
