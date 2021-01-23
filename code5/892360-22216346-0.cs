    public ActionResult UpdateTransportRequests() 
      
    {
    
     string json;
            
     using (var reader = new StreamReader(Request.InputStream))
            {
                json = reader.ReadToEnd();
            }
            
            dynamic jo = JObject.Parse(json);
            foreach (var item in jo.Items)
            {
                decimal reqId = (decimal)item;
                RequestDataAccess rda = new RequestDataAccess();
                rda.AllApproveReject_Request(reqId, "A", "");
            }
            return Json(new { result = "success" });
        }
