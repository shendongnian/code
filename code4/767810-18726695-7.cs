	void SaveButton_Click(object sender, EventArgs e)
	{
		// this could be resolved by dependency injection, this would know about Oracle
		using (var uow = UnitOfWorkFactory.Create()) 
		{
			uow.Applications.Insert(new Application { AuthKey = "1234" });
			
			// you may have other repo that have work done in the same transaction / connection
			
			uow.Commit();
		}
	}
