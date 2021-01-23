    IList<VwItemMaster> vwItemMasterList = this.itemMastersGetByUpc(unitOfWork, upc);
    
    HttpResponseMessage httpResponseMessage = this.Request.CreateResponse<IList<VwItemMaster>>(HttpStatusCode.OK, vwItemMasterList);
    
    httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
