	protected void Page_Load(object sender, EventArgs e)
	{
		RadGrid1.ItemCommand += RadGrid1_ItemCommand;
	}
	protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
	{
		throw new NotImplementedException();
	}
	protected DataTable GetData()
	{
		DataTable tbl = new DataTable();
		tbl.Columns.Add(new DataColumn("Description"));
		tbl.Columns.Add(new DataColumn("ParameterName"));
		tbl.Columns.Add(new DataColumn("ThirdColumn"));
		tbl.Columns.Add(new DataColumn("FourthColumn"));
		tbl.Rows.Add(new object[] { "firstRecord1", "firstRecord2", "firstRecord3", "firstRecord4" });
		tbl.Rows.Add(new object[] { "secondRecord1", "secondRecord2", "secondRecord3", "secondRecord4" });
		tbl.Rows.Add(new object[] { "thirdRecord1", "thirdRecord2", "thirdRecord3", "thirdRecord4" });
		tbl.Rows.Add(new object[] { "fourthRecord1", "fourthRecord2", "fourthRecord3", "fourthRecord4" });
		return tbl;
	}
	protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
	{
		RadGrid1.DataSource=GetData();
	}
