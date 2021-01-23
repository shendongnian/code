		protected void Page_Load(object sender, EventArgs e){
			if (!this.IsPostBack) {
				DataTable dt = new DataTable();
				dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id"), new DataColumn("Name"), new DataColumn("City") });
				dt.Rows.Add(1, "Anamika", "Bangalore");
				dt.Rows.Add(2, "Sunny", "Chennai");
				dt.Rows.Add(3, "Monika", "Bangalore");
				dt.Rows.Add(4, "Jyoti", "Chennai");
				dt.Rows.Add(5, "Radhika", "Jabalpur");
				dt.Rows.Add(6, "Imran", "Jammu");
				dt.Rows.Add(7, "Alok", "Delhi");
				dt.Rows.Add(8, "Amit", "Shamshabad");
				dt.Rows.Add(9, "Neetu", "Bhopal");
				dt.Rows.Add(10, "Jyoti", "Chennai");
				dt.Rows.Add(11, "Radhika", "Vidisha");
				dt.Rows.Add(10, "Pooja", "Pune");
				gridview1.DataSource = dt;
				gridview1.DataBind();
			}
		} 
		
		protected void gridview1_OnRowDataBound(object sender, GridViewRowEventArgs e) {
			if (e.Row.RowType == DataControlRowType.DataRow) {
				for (int i = 0; i < e.Row.Cells.Count; i++) {                 
					TextBox txt = new TextBox();
					txt.Text = e.Row.Cells[i].Text;                 
					e.Row.Cells[i].Text = "";
					e.Row.Cells[i].Controls.Add(txt);
				}
			}
		}
	}
