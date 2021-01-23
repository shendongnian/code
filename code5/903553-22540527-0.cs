     public ActionResult MyFancyMethod()
     {
	     var serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue };
	     var result = new ContentResult
	     {
		     Content = serializer.Serialize(myBigData),
		     ContentType = "application/json"
	     };
	     return result;
    }
