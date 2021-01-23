    public HttpResponseMessage getLogoPath(int id)
    {
    	string pathImage = // a way to get the imagem path..
    	
    	// create response
        HttpResponseMessage response = new HttpResponseMessage(); 
    	
    	// set the content (image)
        response.Content = new StreamContent(new FileStream(pathImage));
    	
    	// set the content type for the respective image
        response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png"); // or jpg, gif..
    	
        return response;
    }
