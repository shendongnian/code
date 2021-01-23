	DataTable DTable = new DataTable();
	BindingSource SBind = new BindingSource();
	SBind.DataSource = DTable;
	DataGridView ServersTable = new DataGridView();
	ServersTable.AutoGenerateColumns = false;
	ServersTable.DataSource = DTable;
	ServersTable.DataSource = SBind;
	ServersTable.Refresh();
