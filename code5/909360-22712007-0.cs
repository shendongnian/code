    [HttpPost]
    public ActionResult Index(HttpPostedFileBase fil)
    {
    	if (fil != null && fil.ContentLength > 0)
    	{
    		// Read bytes from http input stream
    		BinaryReader b = new BinaryReader(file.InputStream);
    		byte[] binData = b.ReadBytes(file.InputStream.Length);
    		string result = System.Text.Encoding.UTF8.GetString(binData);
    		Session["doc2"] = result;
    
    	}
    	return RedirectToAction("Xmlview");
    }
    
    [HttpGet]
    public ActionResult Xmlview()
    {
    	Value model2 = new Value();
    	string strall = "";
        string content = Session["doc2"].ToString();
    	if (!String.IsNullOrEmpty(content))
    	{
    		XDocument xml = XDocument.Parse(content);  
    		var allElements = xml.Elements();
    	}
    }
