  	// Define a custom type to hold the data
	private class TransactionSummary
	{
		public string BatchId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		//...removed lines for brevity...
	}
	//...here is the updated code snippet...
	using (var db = new StarterSiteEntities())
	{   // Get data
		var transactions = (from t in db.Transactions
							join td in db.TransactionDetails on t.TransactionID equals td.TransactionID
							join p in db.Products on td.ProductID equals p.ProductID
							where t.Exported == false
							select new TransactionSummary
							{
								FirstName = t.FirstName,
								LastName = t.LastName,
								//...removed lines for brevity...
							}).ToList();
		// The client would like a batchID added to each record that we return.
		var batchId = context.Request["batchid"];
		transactions.Select(t => { t.BatchId = batchId; return t; }).ToList();
	}
