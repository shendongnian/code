        [Test]
		public void TestAsyncTableQueryToListAsync ()
		{
			var conn = GetConnection ();
			conn.CreateTableAsync<Customer> ().Wait ();
			// create...
			Customer customer = this.CreateCustomer ();
			conn.InsertAsync (customer).Wait ();
			// query...
			var query = conn.Table<Customer> ();
			var task = query.ToListAsync ();
			task.Wait ();
			var items = task.Result;
			// check...
			var loaded = items.Where (v => v.Id == customer.Id).First ();
			Assert.AreEqual (customer.Email, loaded.Email);
		}
