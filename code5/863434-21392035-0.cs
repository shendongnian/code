    private DataTable dt;
    public Form1() {
      InitializeComponent();
      dt = new DataTable();
      dt.Columns.Add("UserName");
      for (int i = 0; i < 120000; ++i){
        DataRow dr = dt.NewRow();
        dr[0] = "user" + i.ToString();
        dt.Rows.Add(dr);
      }
      dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      dgv.AllowUserToAddRows = false;
      dgv.AllowUserToDeleteRows = false;
      dgv.RowHeadersVisible = false;
      dgv.DataSource = dt;
    }
