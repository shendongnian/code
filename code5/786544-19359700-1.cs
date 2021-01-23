    /// <summary>
    /// Handles the POST event for the Delete action.
    /// </summary>
    /// <param name="id">Id of the TEntity object to delete.</param>
    /// <param name="model">TEntity object to delete.</param>
    /// <returns>Redirection to the Index action if succeeded, the Delete View otherwise.</returns>
    [HttpPost]
    public override ActionResult Delete(string id, DeliveryNoteLine model)
    {
        //This code deletes the StockLine
        var stocks_request = new RestSharp.RestRequest("GetStockLine?DeliveryNoteLineId={id}", RestSharp.Method.GET) { RequestFormat = RestSharp.DataFormat.Json }
            .AddParameter("id", id, RestSharp.ParameterType.UrlSegment);
        var stocks_response = Client.Execute(stocks_request);
        var stockline = DeserializeResponse<StockLine>(stocks_response);
        var reqdelstk = new RestSharp.RestRequest("StockLine?id={id}", RestSharp.Method.DELETE) { RequestFormat = RestSharp.DataFormat.Json }
            .AddParameter("id", stockline.Id, RestSharp.ParameterType.UrlSegment);
        var resdelstk = Client.Execute(reqdelstk);
        //This code deletes the DeliveryNoteLine
        var request = new RestSharp.RestRequest(Resource + "?id={id}", RestSharp.Method.DELETE) { RequestFormat = RestSharp.DataFormat.Json }
            .AddParameter("id", id, RestSharp.ParameterType.UrlSegment);
        var response = Client.Execute(request);
        // Handle response errors
        HandleResponseErrors(response);
        if (Errors.Length == 0)
            return RedirectToAction("Index");
        else
        {
            request = new RestSharp.RestRequest(Resource + "?id={id}", RestSharp.Method.GET) { RequestFormat = RestSharp.DataFormat.Json }
                .AddParameter("id", id, RestSharp.ParameterType.UrlSegment);
            response = Client.Execute(request);
            model = DeserializeResponse<DeliveryNoteLine>(response);
            ViewBag.Errors = Errors;
            return View(model);
        }
    }
