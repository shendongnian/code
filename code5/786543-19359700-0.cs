    /// <summary>
    /// Service returning API's StockLine that matches the given DeliveryNote id.
    /// </summary>
    /// <param name="DeliveryNoteLineId">The id of the DeliveryNoteLine that created the StockLine</param>
    /// <returns>Returns the StockLine created by the given DeliveryNoteLine</returns>
    public ActionResult GetStockLine(string DeliveryNoteLineId)
    {
        // Only perform the request if the data is outdated, otherwise use cached data.
        if (DateTime.Now.AddMinutes(-10) > _cacheStockLines_lastCall.GetValueOrDefault(DateTime.MinValue))
        {
            var request = new RestSharp.RestRequest("StockLines/Get", RestSharp.Method.GET) { RequestFormat = RestSharp.DataFormat.Json };
            var response = Client.Execute(request);
            _cacheStockLines = DeserializeResponse<List<StockLine>>(response);
            _cacheStockLines_lastCall = DateTime.Now;
        }
        // Return the stock line created by the delivery note line introduced my parameter
        var ret = _cacheStockLines
            .Where(x => (x.DeliveryNoteLine != null && x.DeliveryNoteLine.Id == DeliveryNoteLineId))
            .Select(x => new { label = "ID", value = x.Id });
        return Json(ret, JsonRequestBehavior.AllowGet);
    }
