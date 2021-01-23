    [Route("api/InventoryItems/PostInventoryItem")]
    public HttpResponseMessage PostInventoryItem([FromUri] InventoryItem ii)
    {
        _inventoryItemRepository.PostInventoryItem(ii.ID, ii.pksize, ii.Description, ii.vendor_id, ii.dept,
            ii.subdept, ii.UnitCost, ii.UnitList, ii.OpenQty, ii.UPC, ii.upc_pack_size, ii.vendor_item, ii.crv_id);
        var response = Request.CreateResponse<InventoryItem>(HttpStatusCode.Created, ii);
        string uri = Url.Link("DefaultApi", new { id = ii.ID });
        response.Headers.Location = new Uri(uri);
        return response;
    }
