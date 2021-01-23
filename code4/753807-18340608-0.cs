	using System.Web.Script.Serialization;
	[HttpPost]
	public ActionResult Index(HttpPostedFileBase file)
	{
		if (file.ContentLength > 0)
		{
			// get contents to string
			string str = (new StreamReader(file.InputStream)).ReadToEnd();
			
			// deserializes string into object
			JavaScriptSerializer jss = new JavaScriptSerializer();
			var d = jss.Deserialize<dynamic>(str);
			
			// once it's an object, you can use do with it whatever you want
		}
	}
