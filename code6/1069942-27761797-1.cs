    public ActionResult Operation(string id)
    {
        var req = Request.InputStream;
    	req.Seek(0, SeekOrigin.Begin);
    	string rawBody = new StreamReader(req).ReadToEnd();
    
    	bool setSomething = false;
    
    	if(bool.TryParse(rawBody, out setSomething))
    	{
            // Do something with 'setSomething'
    		return Json(new { id = id, status = setSomething });
    	}
        throw new ArgumentException(string.Format("{0} is not a valid boolean value", rawBody));
    }
