        public DataTable GetResultsTable()
        {
            using (SqlDatabaseClient client = SqlDatabaseManager.GetClient())
            {
                DataTable _userTable = client.ExecuteQueryTable("SELECT * FROM users");
                DataTable table = new DataTable();
                table.Columns.Add("Username".ToString());
                table.Columns.Add("Motto".ToString());
                table.Columns.Add("Email".ToString());
                table.Columns.Add("Homeroom".ToString());
                table.Columns.Add("Health".ToString());
                table.Columns.Add("Energy".ToString());
                table.Columns.Add("Age".ToString());
                foreach (DataRow _row in _userTable.Rows)
                {
                    DataRow dr = table.NewRow();
                    dr["Username"] = "" + _row["username"] + "";
                    dr["Motto"] = "" + _row["motto"] + "";
                    dr["Email"] = "" + _row["mail"] + "";
                    dr["Homeroom"] = "" + _row["home_room"] + "";
                    dr["Health"] = "" + _row["health"] + "";
                    dr["Energy"] = "" + _row["energy"] + "";
                    dr["Age"] = "" + _row["age"] + "";
                    table.Rows.Add(dr);
                }
                return table;
            }
        }
        public frmMain()
        {
            this.InitializeComponent();
            this.SetupBackstageContent();
            ribbonControl1.SelectedRibbonTabItem = ribbonTabItem1;
            ribbonTabItem2.Text = "&USER CONTROL";
            ribbonTabItem4.Text = "&ADD ONS";
            SqlDatabaseManager.Initialize();
            dataGridView1.DataSource = GetResultsTable();
        }
