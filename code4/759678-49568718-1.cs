	static void ViaDataTable(IDataReader rdr)
	{
		var table = new DataTable();
		table.Load(rdr);
		foreach (DataRow row in table.Rows)
			Console.WriteLine("{0,-27} {1,-46} {2,-25} {3}", row[0], row[1], row[2], row[3]);
	}
    /// ...
	ViaDataTable(DbProviderFactories.GetFactoryClasses().CreateDataReader());
