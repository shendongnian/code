    DataTable dt = new DataTable();
    public newquoteForm()
    {
        InitializeComponent();
        loadTable();
    }
    public void newquoteForm_Load(object sender, EventArgs e)
    {
        getCompanyInfo();
        clearTable();
    }
    private void clearTable()
    {
       DataRow dr;
       dt.Clear();
       dr = dt.NewRow();
       dataGridView1.DataSource = dt;
    }
    private void loadTable()
    {
       dt.Columns.Add("Line");
       dt.Columns.Add("Item Name");
       dt.Columns.Add("Item Description");
       dt.Columns.Add("Retail Price");
       dt.Columns.Add("Supplier Number");
       dt.Columns.Add("Quantity Required");
       dt.Columns.Add("In Stock");
       dt.Columns.Add("Cost Price");
       dt.Columns.Add("Total Cost");
       dt.Columns.Add("Total Retail");
       dt.Columns["Line"].AutoIncrement = true;
       dt.Columns["Line"].AutoIncrementSeed = -1;
       dt.Columns["Line"].AutoIncrementStep = 1;
       dt.Columns["Line"].ReadOnly = true;
       dt.Columns["Item Name"].ReadOnly = true;
       dt.Columns["Item Description"].ReadOnly = true;
       dt.Columns["Cost Price"].ReadOnly = true;
       dt.Columns["In Stock"].ReadOnly = true;
       dt.Columns["Retail Price"].ReadOnly = true;
       dt.Columns["Supplier Number"].ReadOnly = true;
    }
