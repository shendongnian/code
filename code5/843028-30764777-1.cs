	using (var scope = this.OrderManager.BeginTransaction())
	{
		PrintOrder pconnOrder = this.OrderManager.CreateNewOrder(channel, payload, claimsIdentity.Name);
		bool parseResult = this.OrderManager.ParseNewOrder(pconnOrder, claimsIdentity.Name, out parseErrorMessage);
		if (!parseResult)
		{
			// return a fault to the caller
			HttpResponseMessage respMsg = new HttpResponseMessage(HttpStatusCode.BadRequest);
			respMsg.Content = new StringContent(parseErrorMessage);
			throw (new HttpResponseException(respMsg));
		}
		scope.Commit();
		return (pconnOrder.PrintOrderID);
	}
