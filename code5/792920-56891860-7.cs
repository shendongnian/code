		private DataTable DoSomeWorkAsync()
		{			
			System.Data.DataTable table = new System.Data.DataTable();
            Thread.Sleep(4000); // Any long time process
			return table;
		}
