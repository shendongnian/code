     protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				var emps = new DataTable("Employee");
				emps.Columns.Add(new DataColumn() {ColumnName = "EmpId", DataType = Type.GetType("System.Int32")});
				emps.Columns.Add(new DataColumn() {ColumnName = "Name", DataType = Type.GetType("System.String")});
				emps.Columns.Add(new DataColumn() {ColumnName = "Address", DataType = Type.GetType("System.String")});
				var dataSet = new DataSet();
				dataSet.Tables.Add(emps);
				var row = emps.NewRow();
				row["EmpId"] = 1000;
				row["Name"] = "John";
				row["Address"] = "1 Smith St";
				emps.Rows.Add(row);
				GridView1.DataSource = dataSet;
				GridView1.DataBind();
			}
		}
		protected void Button2_Click(object sender, EventArgs e)
		{
			foreach (GridViewRow row in GridView1.Rows)
			{
				if ((row.FindControl("CheckBox1") as CheckBox).Checked)
				{
					TextBox1.Text = row.Cells[1].Text;
					TextBox2.Text = row.Cells[2].Text;
					TextBox3.Text = row.Cells[3].Text;
				}
			}
		}
		protected void Button1_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}
