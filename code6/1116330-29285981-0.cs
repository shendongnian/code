    var client = await db.Client
    	.Where(i => !i.IsDeleted)
    	.FirstOrDefaultAsync(x => x.Id == id);
    
    var top3Invoices = client.Invoices.Take(3);
