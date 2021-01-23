    public HttpResponseMessage Delete(int id)
    {
        if (id < 1) { return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { msg = "ID cannot be null" }); };
        try
        {
            GenericCatalogManagerBL.DeletePart(_genericCNN, id);
            return Request.CreateResponse(HttpStatusCode.Accepted, new { msg = "Part removed" });
        }
        catch (Exception)
        {
            return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { msg = "Part not removed" });
        }
    }
    public HttpResponseMessage DeleteByCatalogID(int genericCatalogID)
    {
        if (genericCatalogID < 1) { return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { msg = "GenericCatalogID cannot be null" }); };
        try
        {
            GenericCatalogManagerBL.DeletePartsAll(_genericCNN, genericCatalogID);
                return Request.CreateResponse(HttpStatusCode.Accepted, new { msg = "Parts removed" });
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, new { msg = "Parts not removed" });
            }
