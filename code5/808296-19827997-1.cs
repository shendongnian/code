	int batchSize = 10000;
	SqlBulkCopy bc = new SqlBulkCopy(con);
	DataTable dtArchivos = new DataTable();
	dtArchivos.Columns.AddRange(new []
	{
		new DataColumn("Codigo", typeof(string)), 
		new DataColumn("Nombre", typeof(string)), 
		new DataColumn("Sueldo", typeof(decimal)), 
	});
	StreamReader file = new StreamReader(@"c:\temp\archivo.txt");
	string line = file.ReadLine();
	while (line != null)
	{
		string[] fields = line.Split(',');
		DataRow dr = dtArchivos.NewRow();
		dr["Codigo"] = fields[0].ToString();
		dr["Nombre"] = fields[1].ToString();
		dr["Sueldo"] = decimal.Parse(fields[2]);
		dtArchivos.Rows.Add(dr);
		if (dtArchivos.Rows.Count == batchSize)
		{
			bc.WriteToServer(dtArchivos);
			dtArchivos.Clear();
		}
		line = file.ReadLine();
	}
	bc.WriteToServer(dtArchivos);
